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
                .Include(r => r.User)
                .Include(r => r.User.Kontakt)
                .Include(r => r.Fahrer)
                .Include(r => r.Fahrer.Kontakt);

            var reiseInfos = new List<ReiseInfo>();
            if (User.IsInRole("Admin"))
            {
                reiseInfos = query.ToList();
            }
            else if (User.IsInRole("Driver"))
            {
                var userId = userManager.GetUserId(HttpContext.User);
                reiseInfos = query.Where(g => g.FahrerId == userId).ToList();
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
            var reiseInfo = context.ReiseInfos.FirstOrDefault(r => r.Id == id);
            reiseInfo.AbgesagtAm = DateTime.Now;
            reiseInfo.AbsageGrund = AbsageGrund;

            context.ReiseInfos.Update(reiseInfo);
            context.Entry(reiseInfo).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Loeschen(int id)
        {
            context.Remove(context.ReiseInfos.Single(reiseInfo => reiseInfo.Id == id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> FahrerZuweisenSubmit(int id, string FahrerId)
        {
            var reiseInfoAusDB = context.ReiseInfos.FirstOrDefault(r => r.Id == id);
            if (reiseInfoAusDB == null) { return BadRequest(); }
            reiseInfoAusDB.FahrerId = FahrerId;
            context.Entry(reiseInfoAusDB).State = EntityState.Modified;
            context.SaveChanges();

            var reiseInfoDetailModel = mapper.Map<ReiseInfoDetailModel>(reiseInfoAusDB);

            reiseInfoDetailModel.alleFahrer = await getAlleFahrer();

            return RedirectToAction("Details", reiseInfoDetailModel);

        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var reiseInfoAusDB = context.ReiseInfos
                .Include(r => r.User)
                .Include(r => r.User.Kontakt)
                .Include(r => r.Fahrer)
                .Include(r => r.Fahrer.Kontakt)
                .FirstOrDefault(r => r.Id == id);

            if (reiseInfoAusDB == null)
            {
                return NotFound();
            }

            var reiseInfoDetailModel = mapper.Map<ReiseInfoDetailModel>(reiseInfoAusDB);

            reiseInfoDetailModel.alleFahrer = await getAlleFahrer();

            ViewBag.ReiseInfo = reiseInfoDetailModel;
            return View();
        }

        private async Task<List<KontaktModel>> getAlleFahrer()
        {
            string roleName = "DRIVER";

            var users = await userManager.GetUsersInRoleAsync(roleName) as List<ApplicationUser>;
            var ids = users.Select(user => user.Id);

            List<Kontakt> kontakts = context.Kontakts
            .Where(e => ids.Contains(e.UserId))
            .ToList();

            return mapper.Map<List<Kontakt>, List<KontaktModel>>(kontakts);
        }
    }
}
