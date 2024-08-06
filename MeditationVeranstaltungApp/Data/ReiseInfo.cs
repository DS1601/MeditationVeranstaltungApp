using MeditationVeranstaltungApp.Shared;
using System;
using System.Collections.Generic;

namespace MeditationVeranstaltungApp.Data
{
    public partial class ReiseInfo
    {
        public ReiseInfo()
        {
           
        }
        public int Id { get; set; }
        public string Veranstalltung { get; set; }
        public int AnzahlMaenner { get; set; }
        public int AnzahlWeiblich { get; set; }
        public DateTime AnkunftAm { get; set; }
        public string AnkunftOrt { get; set; }
        public DateTime AbfahrtAm { get; set; }
        public string AbfahrtOrt { get; set; }
        public DateTime? AbgesagtAm { get; set; }
        public string? AbsageGrund { get; set; }
        public string? Notiz {  get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public string? FahrerId { get; set; }
        public virtual ApplicationUser? Fahrer { get; set; }

    }
}
