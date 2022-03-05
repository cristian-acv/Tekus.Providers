using FluentValidation;

namespace Tekus.Providers.Application.Features.Providers.Commands.UpdateProvider
{
    public class UpdateProviderCommandValidator : AbstractValidator<UpdateProviderCommand>
    {
        public UpdateProviderCommandValidator()
        {

            RuleFor(P => P.NIT)
                .NotEmpty().WithMessage("{NIT} can not be blank")
                .NotNull()
                .MaximumLength(20).WithMessage("{NIT} cannot exceed 100 characters ")
                .MinimumLength(5).WithMessage("{NIT} must be at least 8 characters")
                .Matches(@"^[0-9]+$")
                .WithMessage("The NIT only admits numbers");

            RuleFor(P => P.Name)
                .NotEmpty().WithMessage("{Name} can not be blank")
                .NotNull()
                .MaximumLength(100).WithMessage("{Name} cannot exceed 100 characters ");

            RuleFor(P => P.Description)
                .NotEmpty().WithMessage("{Description} can not be blank")
                .NotNull()
                .MaximumLength(250).WithMessage("{Description} cannot exceed 150 characters ");

            RuleFor(P => P.Email)
                .NotEmpty().WithMessage("{Description} can not be blank")
                .NotNull()
                .EmailAddress().WithMessage("A valid email address is required.");

        }
    }
}
