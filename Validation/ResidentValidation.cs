using FluentValidation;
using REST_API_APARTMENT.DTO.Resident_DTO;

namespace REST_API_APARTMENT.Validation
{
    public class ResidentValidation : AbstractValidator<ResidentDTO>
    {
        public ResidentValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Surname).NotNull().NotEmpty();
            RuleFor(x => x.Person_code).NotNull().Matches(@"\d{6}-\d{5}")
                .WithMessage("Person_code must be a string of 11 digits.");
            RuleFor(x => x.Birth_time).NotNull();
            RuleFor(x => x.Telephone).NotNull();
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.AppartmentId).NotNull();
        }
    }
}