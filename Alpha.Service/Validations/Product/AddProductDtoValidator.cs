using Alpha.Core.Dtos.Products;
using FluentValidation;

namespace Alpha.Service.Validations.Product;

public class AddProductDtoValidator : AbstractValidator<AddProductDto>
{
    public AddProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required")
            .MinimumLength(3).WithMessage("{PropertyName}  must be at long 3 characters")
            .MaximumLength(64).WithMessage("{PropertyName} must be at least 64 characters");
        RuleFor(x => x.Description).MaximumLength(1024).WithMessage("{PropertyName} must be at least 1024 characters");
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
        RuleFor(x => x.Stock)
            .GreaterThan(-1).WithMessage("{PropertyName} can be at least zero");
        RuleFor(x => x.BrandId)
            .GreaterThan(0).WithMessage("{PropertyName} is wrong");
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("{PropertyName} is wrong");
    }
}