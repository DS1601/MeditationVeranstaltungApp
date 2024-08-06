using Microsoft.AspNetCore.Identity;

namespace MeditationVeranstaltungApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        public Kontakt? Kontakt { get; set; }
    }
}
