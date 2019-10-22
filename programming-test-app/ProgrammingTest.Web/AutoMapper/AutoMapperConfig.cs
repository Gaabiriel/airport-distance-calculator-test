using AutoMapper;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Web.Model;

namespace ProgrammingTest.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            this.CreateMap<Airport, AirportModel>()
                .ForMember(dest => dest.City, m => m.MapFrom(src => src.City))
                .ForMember(dest => dest.CityIata, m => m.MapFrom(src => src.CityIata))
                .ForMember(dest => dest.Country, m => m.MapFrom(src => src.Country))
                .ForMember(dest => dest.CountryIata, m => m.MapFrom(src => src.CountryIata))
                .ForMember(dest => dest.Hubs, m => m.MapFrom(src => src.Hubs))
                .ForMember(dest => dest.Iata, m => m.MapFrom(src => src.Iata))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rating, m => m.MapFrom(src => src.Rating))
                .ForMember(dest => dest.TimezoneRegionName, m => m.MapFrom(src => src.TimezoneRegionName))
                .ForMember(dest => dest.Type, m => m.MapFrom(src => src.Type))
                .ForMember(dest => dest.Lat, m => m.MapFrom(src => src.Location.Lat))
                .ForMember(dest => dest.Lon, m => m.MapFrom(src => src.Location.Lon))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
