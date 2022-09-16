using Alpha.Core.Dtos.Brand;
using FluentValidation;

namespace Alpha.Service.Validations.Brand;

public class UpdateBrandDtoValidator : AbstractValidator<UpdateBrandDto>
{
    public UpdateBrandDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
            .NotNull().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required")
            .MinimumLength(3).WithMessage("{PropertyName}  must be at long 3 characters")
            .MaximumLength(64).WithMessage("{PropertyName} must be at least 64 characters");
        RuleFor(x => x.Description).MaximumLength(1024).WithMessage("{PropertyName} must be at least 1024 characters");
    }
}