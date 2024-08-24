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

            CreateMap<ReiseInfo, ReiseInfoListModel>()
                .ForMember(q => q.Anzahl, d => d.MapFrom(map => map.AnzahlMaenner + map.AnzahlFrauen))
                .ForMember(q => q.AnkunftInfo, d => d.MapFrom(map => $"{map.AnkunftAm.ToString("dd.MM.yyyy  HH:mm")} ({map.AnkunftOrt})"))
                .ForMember(q => q.AbfahrtInfo, d => d.MapFrom(map => $"{map.AbfahrtAm.ToString("dd.MM.yyyy  HH:mm")} ({map.AbfahrtOrt})"))
                .ForMember(q => q.istAbgesagt, d => d.MapFrom(map => map.AbgesagtAm !=null))
                .ForMember(q => q.Kontakt, d => d.MapFrom(map => $"{map.User.Kontakt.Vorname} {map.User.Kontakt.Nachname}"))
                .ForMember(q => q.Fahrer, d => d.MapFrom(map => $"{map.Fahrer.Kontakt.Vorname} {map.Fahrer.Kontakt.Nachname}"));

            CreateMap<ReiseInfo, ReiseInfoDetailModel>()
                .ForMember(q => q.AnkunftAm, d => d.MapFrom(map => DateOnly.FromDateTime(map.AnkunftAm)))
                .ForMember(q => q.AnkunftUm, d => d.MapFrom(map => TimeOnly.FromDateTime(map.AnkunftAm)))
                .ForMember(q => q.AbfahrtAm, d => d.MapFrom(map => DateOnly.FromDateTime(map.AbfahrtAm)))
                .ForMember(q => q.AbfahrtUm, d => d.MapFrom(map => TimeOnly.FromDateTime(map.AbfahrtAm)))
                .ForMember(q => q.Kontakt, d => d.MapFrom(map => map.User.Kontakt))
                .ForMember(q => q.Fahrer, d => d.MapFrom(map => map.Fahrer.Kontakt));

            CreateMap<ReiseInfo, ReiseInfoCreateEditModel>()
                .ForMember(q => q.AnkunftAm, d => d.MapFrom(map => DateOnly.FromDateTime(map.AnkunftAm)))
                .ForMember(q => q.AnkunftUm, d => d.MapFrom(map => TimeOnly.FromDateTime(map.AnkunftAm)))
                .ForMember(q => q.AbfahrtAm, d => d.MapFrom(map => DateOnly.FromDateTime(map.AbfahrtAm)))
                .ForMember(q => q.AbfahrtUm, d => d.MapFrom(map => TimeOnly.FromDateTime(map.AbfahrtAm)));
        }
    }
}
