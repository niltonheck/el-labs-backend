using FluentValidation;

namespace CWebService.Application.Models.Brand {
    public class BookingModelValidator: AbstractValidator<BookingRequestModel> {
        public BookingModelValidator() {
            RuleFor(booking => booking.NumberOfHours)
                .NotEmpty()
                .WithMessage("Field 'numberOfHours' is required.");

            RuleFor(booking => booking.NumberOfHours)
                .GreaterThan(0)
                .WithMessage("Field 'numberOfHours' must be greater than zero.");

            RuleFor(booking => booking.UserId)
                .NotEmpty()
                .WithMessage("Field 'userId' is required.");

            RuleFor(booking => booking.UserId)
                .NotEmpty()
                .WithMessage("Field 'userId' is required.");

            RuleFor(booking => booking.VehicleId)
                .NotEmpty()
                .WithMessage("Field 'vehicleId' is required.");

            RuleFor(booking => booking.InitialDateTime)
                .NotEmpty()
                .WithMessage("Field 'initialDateTie' is required.");

            RuleFor(booking => booking.FinalDateTime)
                .NotEmpty()
                .WithMessage("Field 'finalDateTime' is required.");
        }
    }
}