using FluentValidation;
using NLayer.Core.DTOs;


namespace NLayer.Service.Validators
{
    public class ProductDtoValidations : AbstractValidator<ProductDto>
    {
        public ProductDtoValidations()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} can't be null").NotEmpty()
                .WithMessage("{PropertyName} can't be empty").InclusiveBetween(1, int.MaxValue);
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} can't be empty").NotNull().
                WithMessage("{PropertyName} can't be null");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue)
                .WithMessage("{PropertyName} Price must be greater than 0");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue)
                .WithMessage("{{PropertyName} must be greater than 0}");
        }
    }
}
