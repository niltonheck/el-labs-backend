using System.Text.RegularExpressions;
using CWebService.Domain.Enums;
using FluentValidation;

namespace CWebService.Application.Models.Brand {
    public class VehicleModelValidator: AbstractValidator<VehicleModel> {
        public VehicleModelValidator() {
            RuleFor(vehicle => vehicle.Plate)
                .NotEmpty()
                .Custom((plate, context) => {
                    Regex rx = new Regex(@"[A-Z]{3}\d[A-Z]\d{2}|[A-Z]{3}\d{4}",RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    MatchCollection matches = rx.Matches(plate);
                    if(matches.Count == 0) {
                        context.AddFailure("plate", "Field 'plate' is invalid.");
                    }
                });

            RuleFor(vehicle => vehicle.BrandId)
                .NotEmpty()
                .WithMessage("Field 'brandId' is required.");

            RuleFor(vehicle => vehicle.Plate)
                .NotEmpty()
                .WithMessage("Field 'plate' is required.");

            RuleFor(vehicle => vehicle.ModelId)
                .NotEmpty()
                .WithMessage("Field 'modelId' is required.");

            RuleFor(vehicle => vehicle.Year)
                .NotEmpty()
                .WithMessage("Field 'year' is required.");

            RuleFor(vehicle => vehicle.Year)
                .GreaterThan(1990)
                .WithMessage("Field 'costPerHour' invalid.");
        
            RuleFor(vehicle => vehicle.CostPerHour)
                .NotEmpty()
                .WithMessage("Field 'costPerHour' is required.");

            RuleFor(vehicle => vehicle.CostPerHour)
                .GreaterThan(0)
                .WithMessage("Field 'costPerHour' must be greater than zero.");

            RuleFor(vehicle => vehicle.FuelType)
                .NotEmpty()
                .WithMessage("Field 'fuelType' is required.");
            
            RuleFor(vehicle => vehicle.FuelType)
                .IsInEnum()
                .WithMessage("Field 'fuelType' invalid.");

            RuleFor(vehicle => vehicle.TrunkCapacity)
                .NotEmpty()
                .WithMessage("Field 'trunkCapacity' is required.");
            
            RuleFor(vehicle => vehicle.Category)
                .NotEmpty()
                .WithMessage("Field 'category' is required.");

            RuleFor(vehicle => vehicle.Category)
                .IsInEnum()
                .WithMessage("Field 'category' invalid.");
        }
    }
}