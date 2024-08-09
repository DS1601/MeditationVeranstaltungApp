using AutoMapper;
using MeditationVeranstaltungApp.Data;
using MeditationVeranstaltungApp.Models;
//using BookStoreApp.API.Models.Book;
//using BookStoreApp.API.Models.User;

namespace MeditationVeranstaltungApp.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Kontakt, KontaktModel>()
                .ForMember(km => km.KontaktId, k => k.MapFrom(map => map.Id))
                .ReverseMap();
        }
    }
}
