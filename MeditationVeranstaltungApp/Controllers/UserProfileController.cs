using AutoMapper;
using MeditationVeranstaltungApp.Data;
using MeditationVeranstaltungApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace MeditationVeranstaltungApp.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly ILogger<UserProfileController> _logger;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserProfileController(
            ILogger<UserProfileController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            ApplicationDbContext context
            )
        {
            _logger = logger;
            _userManager = userManager;
            this._signInManager = signInManager;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            string roleName = "User";

            var users = await _userManager.GetUsersInRoleAsync(roleName) as List<ApplicationUser>;
            var ids = users.Select(user => user.Id);

            List<Kontakt> kontakts = context.Kontakts
            .Where(e => ids.Contains(e.UserId))
            .ToList();
            var kontaktModels = mapper.Map<List<Kontakt>, List<KontaktModel>>(kontakts);

            ViewBag.KontaktModels = kontaktModels;
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
                kontaktModel.UserId = id;
            }
            else
            {
                kontaktModel = new KontaktModel
                {
                    UserId = id
                };

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

        public async Task<ActionResult> ChangePassword(string altesPasswort, string neuesPasswort)
        {
            if (altesPasswort != null && neuesPasswort != null)
            {

                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, altesPasswort, neuesPasswort);
                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return RedirectToAction("Error", "sshshss shhshs");
                }

                await _signInManager.RefreshSignInAsync(user);
                _logger.LogInformation("User changed their password successfully.");
                return RedirectToAction("ChangePasswordConfirmation");
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult ChangePasswordConfirmation()
        {
            return View();
        }
    }
}
