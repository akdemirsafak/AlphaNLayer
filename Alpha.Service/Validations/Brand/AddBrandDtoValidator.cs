using Alpha.Core.Dtos.Brand;
using FluentValidation;

namespace Alpha.Service.Validations.Brand;

public class AddBrandDtoValidator : AbstractValidator<AddBrandDto>
{
    public AddBrandDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MinimumLength(3).WithMessage("{PropertyName}  must be at long 3 characters")
            .MaximumLength(64).WithMessage("{PropertyName} must be no more than 64 characters long.");
        RuleFor(x => x.Description)
            .MaximumLength(1024).WithMessage("{PropertyName} must be no more than 1024 characters long.");
    }
}