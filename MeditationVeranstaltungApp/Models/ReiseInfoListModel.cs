using MeditationVeranstaltungApp.Configurations;
using MeditationVeranstaltungApp.Shared;
using System;
using System.Collections.Generic;

namespace MeditationVeranstaltungApp.Models
{
    public partial class ReiseInfoListModel
    {
        public ReiseInfoListModel()
        {

        }
        public int Id { get; set; }
        public string Veranstalltung { get; set; }
        public int Anzahl { get; set; }
        public string AnkunftInfo { get; set; }
        public string AbfahrtInfo { get; set; }
        public string Kontakt { get; set; }
        public string Fahrer { get; set; }
        public bool istAbgesagt { get; set; }
    }
}
