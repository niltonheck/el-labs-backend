using FluentValidation;

namespace CWebService.Application.Models.Brand {
    public class ModelModelValidator: AbstractValidator<ModelModel> {
        public ModelModelValidator() {
            RuleFor(model => model.Name)
                .NotEmpty()
                .WithMessage("Field 'name' is required.");

            RuleFor(model => model.BrandID)
                .NotEmpty()
                .WithMessage("Field 'brandId' is required.");
        }
    }
}