using AutoMapper;

namespace REST_API_APARTMENT.DTO.Resident_DTO

{
    public class ResidentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Person_code { get; set; }
        public DateTimeOffset Birth_time { get; set; }

        public int Telephone { get; set; }
        public string Email { get; set; }

        public int AppartmentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Resident, ResidentDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Person_code, opt => opt.MapFrom(src => src.Person_code))
                .ForMember(dest => dest.Birth_time, opt => opt.MapFrom(src => src.Birth_time))
                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.Telephone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.AppartmentId, opt => opt.MapFrom(src => src.AppartmentId))
                ;
        }
    }
}