using AutoMapper;
using MeditationVeranstaltungApp.Data;
using MeditationVeranstaltungApp.Models;
//using BookStoreApp.API.Models.Book;
//using BookStoreApp.API.Models.User;

namespace MeditationVeranstaltungApp.Configurations
{
    public static class Globals
    {
        public static string Veranstalltung = "MV24HH";
        public static DateOnly start = new DateOnly(2024, 12, 24);
        public static DateOnly end = new DateOnly(2024, 12, 29);
    }
}
