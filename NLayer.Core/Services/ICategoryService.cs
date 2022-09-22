using NLayer.Core.DTOs;
using NLayer.Core.Entites;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetCategorybyIdWithProductsAsync(int categoryId);
        Task<CustomResponseDto<List<CategoryWithProductsDto>>> GetAllCategoriesWithProductsAsync();
    }
}
