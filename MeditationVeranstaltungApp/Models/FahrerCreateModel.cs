using MeditationVeranstaltungApp.Data;
using MeditationVeranstaltungApp.Shared;

namespace MeditationVeranstaltungApp.Models
{
    public class FahrerCreateModel
    {
        public string Passwort { get; set; }
        public Anrede Anrede { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }

    }
}
