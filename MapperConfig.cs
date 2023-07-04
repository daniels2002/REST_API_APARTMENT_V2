using AutoMapper;
using REST_API_APARTMENT;
using REST_API_APARTMENT.DTO.Appartment_DTO;
using REST_API_APARTMENT.DTO.House_DTO;
using REST_API_APARTMENT.DTO.Resident_DTO;
using REST_API_APARTMENT.Models;

public class MapperConfig
{
    public static IMapper InitializeAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Appartment, AppartmentDTO>();
            cfg.CreateMap<House, HouseDTO>();
            cfg.CreateMap<Resident, ResidentDTO>();
        });

        IMapper mapper = config.CreateMapper();
        return mapper;
    }
}