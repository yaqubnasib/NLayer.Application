using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class CategoryApiService : BaseApiService
    {
        public CategoryApiService(HttpClient _httpClient) : base(_httpClient)
        {
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>
                ("categories");
            return response.Data;
        }

        public async Task<List<CategoryWithProductsDto>> GetAllCategoriesWithProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryWithProductsDto>>>
                ("categories/GetAllCategoriesWithProductsAsync");
            return response.Data;
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CategoryDto>>
                ($"categories/{id}");
            return response.Data;
        }

        public async Task<bool> UpdateAsync(CategoryDto updateCategory)
        {
            var response = await _httpClient.PostAsJsonAsync("categories", updateCategory);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"categories/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<CategoryDto> SaveAsync(CategoryDto newCategory)
        {
            var response = await _httpClient.PostAsJsonAsync("categories", newCategory);
            if(!response.IsSuccessStatusCode)
                return null; //Task: Throw exception Later

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CategoryDto>>();
            return responseBody.Data;
        }
    }
}
