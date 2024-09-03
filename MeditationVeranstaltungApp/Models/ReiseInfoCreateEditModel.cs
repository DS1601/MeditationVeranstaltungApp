using MeditationVeranstaltungApp.Configurations;
using MeditationVeranstaltungApp.Shared;
using System;
using System.Collections.Generic;

namespace MeditationVeranstaltungApp.Models
{
    public partial class ReiseInfoCreateEditModel
    {
        public ReiseInfoCreateEditModel()
        {

        }
        public int Id { get; set; }
        public string Veranstalltung = Globals.Veranstalltung;
        public int AnzahlMaenner { get; set; }
        public int AnzahlFrauen { get; set; }
        public DateOnly AnkunftAm { get; set; }
        public TimeOnly AnkunftUm { get; set; }
        public string AnkunftOrt { get; set; }
        public string Ankunftsmittelnummer { get; set; }
        public DateOnly AbfahrtAm { get; set; }
        public TimeOnly AbfahrtUm { get; set; }
        public string AbfahrtOrt { get; set; }
        public string Abfahrtsmittelnummer { get; set; }
        public string? Notiz { get; set; }

    }
}
