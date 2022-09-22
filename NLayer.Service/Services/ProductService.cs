using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entites;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> _repository, IUnitOfWork _unitOfWork, IProductRepository _productRepository, IMapper _mapper)
            : base(_repository, _unitOfWork)
        {
            this._mapper = _mapper;
            this._productRepository = _productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var productsWithCategory = await _productRepository.GetProductsWithCategoryAsync();
            var productWithCategoryDto = _mapper.Map<List<ProductWithCategoryDto>>(productsWithCategory);

            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(productWithCategoryDto, 200);
        }
    }
}
