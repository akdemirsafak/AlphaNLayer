using Alpha.Core.Dtos.Category;
using FluentValidation;

namespace Alpha.Service.Validations.Category;

public class AddCategoryValidator : AbstractValidator<AddCategoryDto>
{
    public AddCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required")
            .MinimumLength(3).WithMessage("{PropertyName}  must be max. 3 characters")
            .MaximumLength(64).WithMessage("{PropertyName} must be min. 64 characters");
    }

    public string Name { get; set; }
}