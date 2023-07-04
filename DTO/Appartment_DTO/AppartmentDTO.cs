using AutoMapper;
using REST_API_APARTMENT.Models;

namespace REST_API_APARTMENT.DTO.Appartment_DTO
{
    public class AppartmentDTO
    {
        public int Id { get; set; }

        //Izmantot fluent configuration
        public int Number { get; set; }

        public int Floor { get; set; }

        public int Rooms { get; set; }

        public int Residents { get; set; }
        public double LivingSpace { get; set; }
        public double TotalSpace { get; set; }
        public int HouseId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Appartment, AppartmentDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Floor))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.Residents, opt => opt.MapFrom(src => src.Residents))
                .ForMember(dest => dest.LivingSpace, opt => opt.MapFrom(src => src.LivingSpace))
                .ForMember(dest => dest.TotalSpace, opt => opt.MapFrom(src => src.TotalSpace))
                .ForMember(dest => dest.HouseId, opt => opt.MapFrom(src => src.HouseId));
        }
    }
}