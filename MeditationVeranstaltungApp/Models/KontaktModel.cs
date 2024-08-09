using MeditationVeranstaltungApp.Data;
using MeditationVeranstaltungApp.Shared;

namespace MeditationVeranstaltungApp.Models
{
    public class KontaktModel
    {
        public int KontaktId { get; set; }
        public Anrede Anrede { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }
        public string UserId { get; set; }

    }
}
