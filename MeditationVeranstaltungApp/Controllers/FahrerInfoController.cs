using AutoMapper;
using MeditationVeranstaltungApp.Data;
using MeditationVeranstaltungApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Xml.Linq;


namespace MeditationVeranstaltungApp.Controllers
{
    public class FahrerInfoController : Controller
    {
        private readonly ILogger<UserProfileController> _logger;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;

        public FahrerInfoController(
            ILogger<UserProfileController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IUserStore<ApplicationUser> userStore,
            IMapper mapper,
            ApplicationDbContext context
            )
        {
            _logger = logger;
            _userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._userStore = userStore;
            this.mapper = mapper;
            this.context = context;
            this._emailStore = GetEmailStore();
        }

        public async Task<IActionResult> Index()
        {
            string roleName = "DRIVER";

            var users = await _userManager.GetUsersInRoleAsync(roleName) as List<ApplicationUser>;
            var ids = users.Where(user => user.LockoutEnd == null || user.LockoutEnd < DateTime.Now).Select(user => user.Id);

            List<Kontakt> kontakts = context.Kontakts
            .Where(e => ids.Contains(e.UserId))
            .ToList();
            var kontaktModels = mapper.Map<List<Kontakt>, List<KontaktModel>>(kontakts);

            ViewBag.KontaktModels = kontaktModels;
            return View();
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public async Task<IActionResult> FahrerSubmit(FahrerCreateModel fahrerCreateModel)
        {
            if (fahrerCreateModel != null)
            {
                var user = new ApplicationUser();

                user.Kontakt = new Kontakt
                {
                    Anrede = fahrerCreateModel.Anrede,
                    Vorname = fahrerCreateModel.Vorname,
                    Nachname = fahrerCreateModel.Nachname,
                    Email = fahrerCreateModel.Email,
                    Telefon = fahrerCreateModel.Telefon,
                    Stadt = fahrerCreateModel.Stadt,
                    Land = fahrerCreateModel.Land,
                };

                await _userStore.SetUserNameAsync(user, fahrerCreateModel.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, fahrerCreateModel.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, fahrerCreateModel.Passwort);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "DRIVER");
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var kontaktAusDB = context.Kontakts
                          .FirstOrDefault(k => k.Id == id);

            if (kontaktAusDB == null)
            {
                return NotFound();
            }

            var kontaktModel = mapper.Map<KontaktModel>(kontaktAusDB);

            ViewBag.FahrerInfo = kontaktModel;
            return View();
        }


        public async Task<IActionResult> deactivate(string userId)
        {
            var lockoutEndDate = new DateTime(2999, 01, 01);
            var user = context.Users.Where(user => user.Id == userId).FirstOrDefault();
            await _userManager.SetLockoutEnabledAsync(user, true);
            await _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);
            return RedirectToAction("Index");
        }
        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
