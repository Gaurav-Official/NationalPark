using AutoMapper;
using NationlParkAPI_2.Models;
using NationlParkAPI_2.Models.DTOs;

namespace NationlParkAPI_2.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<NationalParkDto, NationalPark>().ReverseMap();
            CreateMap<TrailDto, Trail>().ReverseMap();
        }
    }
}
