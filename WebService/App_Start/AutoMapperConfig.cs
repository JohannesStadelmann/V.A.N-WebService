using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebService.Models;
using WebService.ViewModels;

namespace WebService.App_Start {
    public class AutoMapperConfig {

        public static void Initialize() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Address, AddressVM>();
                cfg.CreateMap<AddressVM, Address>();

                cfg.CreateMap<FrequentlyOpen, FrequentlyOpenVM>();
                cfg.CreateMap<FrequentlyOpenVM, FrequentlyOpen>();

                cfg.CreateMap<Location, LocationVM>()
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                    .ForMember(dest => dest.GPSLatitude, opt => opt.MapFrom(src => src.Address.GPSLatitude))
                    .ForMember(dest => dest.GPSLongitude, opt => opt.MapFrom(src => src.Address.GPSLongitude))
                    .ForMember(dest => dest.Typ, opt => opt.MapFrom(src => src.Typ.Name));
                //cfg.CreateMap<LocationVM, Location>();

                cfg.CreateMap<Location, LocationDetailedVM>();
                cfg.CreateMap<LocationDetailedVM, Location>();

                cfg.CreateMap<MusicGenre, MusicGenreVM>();
                cfg.CreateMap<MusicGenreVM, MusicGenre>();

                cfg.CreateMap<OpenHoursException, OpenHoursExceptionVM>();
                cfg.CreateMap<OpenHoursExceptionVM, OpenHoursException>();

                cfg.CreateMap<Rating, RatingVM>();
                cfg.CreateMap<RatingVM, Rating>();

                cfg.CreateMap<Typ, TypVM>();
                cfg.CreateMap<TypVM, Typ>();
            });

        }

    }
}