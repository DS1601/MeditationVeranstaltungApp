
using MeditationVeranstaltungApp.Shared;
using System;
using System.Collections.Generic;

namespace MeditationVeranstaltungApp.Data
{
    public partial class Kontakt
    {
        public Kontakt()
        {
           
        }
        public int Id { get; set; }
        public Anrede Anrede { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; } 
        public string Telefon { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
