using FluentValidation;
using NLayer.Core.DTOs;
using NLayer.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class ProductWithCategoryDtoValidations : AbstractValidator<ProductWithCategoryDto>
    {
        public ProductWithCategoryDtoValidations()
        {

        }
    }
}
