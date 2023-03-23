using AutoMapper;
using BusinessLL.DTOS;
using DomainLL.Models;

namespace VehicleBranding
{
    public class MappingConfig 
    {
        public static MapperConfiguration RegisterMapper()
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<VehicleModel,VehicleModelDTO>().ReverseMap();
                config.CreateMap<VehicleColorMapping,VehicleColorMappingDTO>().ReverseMap();

            });
            return mapper;
        }
    }
}
