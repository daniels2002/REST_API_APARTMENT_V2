using FluentValidation;
using REST_API_APARTMENT.DTO.House_DTO;

namespace REST_API_APARTMENT.Validation
{
    public class HouseValidation : AbstractValidator<HouseDTO>
    {
        public HouseValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.Postcode).NotNull();
        }
    }
}