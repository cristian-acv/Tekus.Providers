using FluentValidation;

namespace Tekus.Providers.Application.Features.Services.Commands.UpdateService
{

    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {


            RuleFor(P => P.Name)
                .NotEmpty().WithMessage("{Name} can not be blank")
                .NotNull()
                .MaximumLength(100).WithMessage("{Name} cannot exceed 100 characters ");

            RuleFor(P => P.Description)
                .NotEmpty().WithMessage("{Description} can not be blank")
                .NotNull()
                .MaximumLength(250).WithMessage("{Description} cannot exceed 250 characters ");

            RuleFor(p => p.ValuePerHour)
                .NotEmpty().WithMessage("{ValuePerHour} can not be blank")
                .NotNull();

            RuleFor(P => P.Country)
                .NotEmpty().WithMessage("{Country} can not be blank")
                .NotNull()
                .MaximumLength(100).WithMessage("{Country} cannot exceed 100 characters ");

        }
    }
}
