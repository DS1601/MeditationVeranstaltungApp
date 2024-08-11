using AutoMapper;
using MeditationVeranstaltungApp.Data;
using MeditationVeranstaltungApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeditationVeranstaltungApp.Controllers
{
    [Authorize]
    public class ReiseInfoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public ReiseInfoController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IMapper mapper
            )
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var query = context.ReiseInfos
                .Include(g => g.User)
                .Include(g => g.User.Kontakt)
                .Include(g => g.Fahrer)
                .Include(g => g.Fahrer.Kontakt);

            var reiseInfos = new List<ReiseInfo>();
            if (User.IsInRole("Admin"))
            {
                reiseInfos = query.ToList();
            }
            else
            {
                var userId = userManager.GetUserId(HttpContext.User);
                reiseInfos = query.Where(g => g.UserId == userId).ToList();
            }

            var reiseInfoListModels = mapper.Map<List<ReiseInfo>, List<ReiseInfoListModel>>(reiseInfos);

            ViewBag.ReiseInfos = reiseInfoListModels;
            return View();
        }

        public IActionResult CreateEditReiseInfo(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var reiseInfoAusDB = context.ReiseInfos.Include(q => q.User).FirstOrDefault(g => g.Id == id);

            if (reiseInfoAusDB == null)
            {
                return NotFound();
            }

            var reiseInfoCreateEditModel = mapper.Map<ReiseInfoCreateEditModel>(reiseInfoAusDB);
            return View("CreateEditReiseInfo", reiseInfoCreateEditModel);
        }

        public IActionResult CreateEditReiseInfoSubmit(ReiseInfoCreateEditModel reiseInfoCreateEditModel)
        {
            if (reiseInfoCreateEditModel != null)
            {

                var reiseInfo = new ReiseInfo();
                reiseInfo.UserId = userManager.GetUserId(HttpContext.User);

                if (reiseInfoCreateEditModel.Id != 0)
                {
                    reiseInfo = context.ReiseInfos.FirstOrDefault(g => g.Id == reiseInfoCreateEditModel.Id);
                    if (reiseInfo == null)
                    {
                        return NotFound();
                    }
                }

                reiseInfo.Veranstalltung = reiseInfoCreateEditModel.Veranstalltung;
                reiseInfo.AnzahlMaenner = reiseInfoCreateEditModel.AnzahlMaenner;
                reiseInfo.AnzahlFrauen = reiseInfoCreateEditModel.AnzahlFrauen;
                reiseInfo.AnkunftAm = reiseInfoCreateEditModel.AnkunftAm.ToDateTime(reiseInfoCreateEditModel.AnkunftUm);
                reiseInfo.AnkunftOrt = reiseInfoCreateEditModel.AnkunftOrt;
                reiseInfo.AbfahrtAm = reiseInfoCreateEditModel.AbfahrtAm.ToDateTime(reiseInfoCreateEditModel.AbfahrtUm);
                reiseInfo.AbfahrtOrt = reiseInfoCreateEditModel.AbfahrtOrt;
                reiseInfo.Notiz = reiseInfoCreateEditModel.Notiz;


                if (reiseInfo.Id == 0)
                {
                    context.ReiseInfos.Add(reiseInfo);
                }
                else
                {
                    context.ReiseInfos.Update(reiseInfo);
                    context.Entry(reiseInfo).State = EntityState.Modified;

                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }


        }
        public IActionResult Absage(int id, string? AbsageGrund)
        {
            var gastInfo = context.ReiseInfos.FirstOrDefault(g => g.Id == id);
            gastInfo.AbgesagtAm = DateTime.Now;
            gastInfo.AbsageGrund = AbsageGrund;

            context.ReiseInfos.Update(gastInfo);
            context.Entry(gastInfo).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult FahrerZuweisen(int id)
        //{
        //    var fahrerZuweisenModel = new FahrerZuweisenModel
        //    {
        //        gastInfoId = id
        //    };
        //    return View("FahrerZuweisen", fahrerZuweisenModel);
        //}

        //public IActionResult FahrerZuweisenSubmit(FahrerZuweisenModel fahrerZuweisenModel)
        //{
        //    var gastInfoAusDB = context.GastInfos.FirstOrDefault(g => g.Id == fahrerZuweisenModel.gastInfoId);

        //    var fahrerKontakt = context.Kontakts
        //        .Where(k => k.Vorname == fahrerZuweisenModel.Vorname &&
        //        k.Nachname == fahrerZuweisenModel.Nachname &&
        //        k.Telefon == fahrerZuweisenModel.Telefon &&
        //        k.Stadt == fahrerZuweisenModel.Stadt &&
        //        k.Land == fahrerZuweisenModel.Land
        //        ).FirstOrDefault();

        //    if (fahrerKontakt != null)
        //    {
        //        gastInfoAusDB.FahrerKontaktId = fahrerKontakt.Id;
        //        gastInfoAusDB.FahrerKontakt = fahrerKontakt;
        //    }
        //    else
        //    {
        //        gastInfoAusDB.FahrerKontakt = new Kontakt
        //        {
        //            Anrede = fahrerZuweisenModel.Anrede,
        //            Vorname = fahrerZuweisenModel.Vorname,
        //            Nachname = fahrerZuweisenModel.Nachname,
        //            Geschlecht = fahrerZuweisenModel.Geschlecht,
        //            Email = fahrerZuweisenModel.Email,
        //            Telefon = fahrerZuweisenModel.Telefon,
        //            Stadt = fahrerZuweisenModel.Stadt,
        //            Land = fahrerZuweisenModel.Land,
        //        };

        //    }


        //    context.Entry(gastInfoAusDB).State = EntityState.Modified;
        //    context.SaveChanges();
        //    return RedirectToAction("Details", gastInfoAusDB);
        //}

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var reiseInfoAusDB = context.ReiseInfos
                .Include(g => g.User)
                .Include(g => g.User.Kontakt)
                .Include(g => g.Fahrer)
                .Include(g => g.Fahrer.Kontakt)
                .FirstOrDefault(g => g.Id == id);

            if (reiseInfoAusDB == null)
            {
                return NotFound();
            }

            var reiseInfoDetailModel = mapper.Map<ReiseInfoDetailModel>(reiseInfoAusDB);

            ViewBag.ReiseInfo = reiseInfoDetailModel;
            return View();
        }
    }
}
