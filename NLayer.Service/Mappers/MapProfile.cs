using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mappers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();   
            CreateMap<ProductFeature,ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductWithCategoryDto,Product>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>();
        }
        
    }
}
