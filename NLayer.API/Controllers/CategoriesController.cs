using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Entites;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        IMapper _mapper;

        public CategoriesController(ICategoryService _categoryService, IMapper _mapper)
        {
            this._categoryService = _categoryService;
            this._mapper = _mapper;
        }


        [HttpGet("api/[controller]/[action]/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdWithProductsAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetCategorybyIdWithProductsAsync(categoryId));
        }

        [HttpGet("api/[controller]/[action]")]
        public async Task<IActionResult> GetAllCategoriesWithProductsAsync()
        {
            return CreateActionResult(await _categoryService.GetAllCategoriesWithProductsAsync());
        }


        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(categoryDto, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);

            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(categoriesDtos, 200));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryService.UpdateAsync(category);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CategoryDto categoryDto)
        {
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            var insertedCategoryDto = _mapper.Map<CategoryDto>(category);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(insertedCategoryDto, 200));
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteAsync(int categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);
            await _categoryService.RemoveAsync(category);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
