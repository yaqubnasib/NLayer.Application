using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entites;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> _repository, IUnitOfWork _unitOfWork
        , ICategoryRepository categoryRepository, IMapper mapper) : base(_repository, _unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategorybyIdWithProductsAsync(int categoryId)
        {
            var categoryWithProducts = await _categoryRepository.GetCategoryByIdWithProductsAsync(categoryId);
            var categoryWithProductsDto = _mapper.Map<CategoryWithProductsDto>(categoryWithProducts);

            return CustomResponseDto<CategoryWithProductsDto>.Success(categoryWithProductsDto, 200);
        }

        public async Task<CustomResponseDto<List<CategoryWithProductsDto>>> GetAllCategoriesWithProductsAsync()
        {
            var categoriesWithProducts = await _categoryRepository.GetAllCategoriesWithProductsAsync();
            var cetgoriesWithProductsDto = _mapper.Map<List<CategoryWithProductsDto>>(categoriesWithProducts);

            return CustomResponseDto<List<CategoryWithProductsDto>>.Success(cetgoriesWithProductsDto, 200);
        }

    }
}
