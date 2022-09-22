using FluentValidation;
using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class CategoryDtoValidations : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidations()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("{PropertyName} can' be null or empty").MaximumLength(50)
                .WithMessage("{PropertyName} must be less than 50");
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue)
                .WithMessage("{PropertyName} must be between 1 and 2 000 000");
        }
    }
}
