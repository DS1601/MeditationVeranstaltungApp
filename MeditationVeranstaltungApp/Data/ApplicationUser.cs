using Microsoft.AspNetCore.Identity;

namespace MeditationVeranstaltungApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        public Kontakt? Kontakt { get; set; }
        public ICollection<ReiseInfo> ReiseInfos { get; set; }
        public ICollection<ReiseInfo> Tours { get; set; }
    }
}
