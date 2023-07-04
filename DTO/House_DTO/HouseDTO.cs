using AutoMapper;
using REST_API_APARTMENT.Models;

namespace REST_API_APARTMENT.DTO.House_DTO
{
    public class HouseDTO
    {
        //primary key cannot be changed
        public int Id { get; set; }

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public int Postcode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<House, HouseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Postcode, opt => opt.MapFrom(src => src.Postcode))
                ;
        }
    }
}