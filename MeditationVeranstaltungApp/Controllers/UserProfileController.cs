using AutoMapper;
using MeditationVeranstaltungApp.Data;
using MeditationVeranstaltungApp.Models;
using MeditationVeranstaltungApp.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Packaging.Signing;
using System.Diagnostics;

namespace MeditationVeranstaltungApp.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly ILogger<UserProfileController> _logger;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public UserProfileController(ILogger<UserProfileController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            this.mapper = mapper;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return View();
            }

            var user = context.Users.Include(k => k.Kontakt).FirstOrDefault(g => g.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            KontaktModel? kontaktModel = null;

            if (user.Kontakt != null)
            {
                kontaktModel = mapper.Map<KontaktModel>(user.Kontakt);
            }

            return View("Edit", kontaktModel);
        }

        public IActionResult UserSubmit(KontaktModel kontaktModel)
        {
            if (kontaktModel != null)
            {

                var kontakt = mapper.Map<Kontakt>(kontaktModel);

                if (kontaktModel.KontaktId == 0)
                {
                    context.Kontakts.Add(kontakt);
                }
                else
                {
                    context.Kontakts.Update(kontakt);
                    context.Entry(kontakt).State = EntityState.Modified;

                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }


        }

    }
}
