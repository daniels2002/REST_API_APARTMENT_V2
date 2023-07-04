using FluentValidation;
using REST_API_APARTMENT.DTO.Appartment_DTO;

namespace REST_API_APARTMENT.Validation
{
    public class AppartmentValidation : AbstractValidator<AppartmentDTO>
    {
        public AppartmentValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Number).NotNull();
            RuleFor(x => x.Floor).NotNull().LessThan(12).WithMessage("Maximum floor number cannot be higher than 12");
            RuleFor(x => x.Rooms).NotNull();
            RuleFor(x => x.Residents).NotNull();
            RuleFor(x => x.LivingSpace).NotNull();
            RuleFor(x => x.TotalSpace).NotNull();
            RuleFor(x => x.HouseId).NotNull();
        }
    }
}