using FluentValidation;

namespace CWebService.Application.Models.Brand {
    public class BrandModelValidator: AbstractValidator<BrandModel> {
        public BrandModelValidator() {
            RuleFor(brand => brand.Name)
                .NotEmpty()
                .WithMessage("Field 'name' is required.");
        }
    }
}