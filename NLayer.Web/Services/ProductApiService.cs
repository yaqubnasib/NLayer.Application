using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class ProductApiService : BaseApiService
    {
        public ProductApiService(HttpClient _httpClient):base(_httpClient) {}


        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>
                ("Products/Products/GetProductsWithCategory");
            return response.Data;

            //string a = "https://localhost:7004/api/Products/api/Products/GetProductsWithCategory"
        }

        public async Task<ProductDto> SaveAsync(ProductDto newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("products", newProduct);

            if (!response.IsSuccessStatusCode)
                return null; //maybe Throw Exception Later 

            var responsebody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return responsebody.Data;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");

            if (response.Errors.Any())
            {
                //Log Errors
            }
            return response.Data;
        }

        public async Task<bool> UpdateAsync(ProductDto updateProduct)
        {
            var response = await _httpClient.PutAsJsonAsync("products",updateProduct);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");
            return response.IsSuccessStatusCode;    
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductDto>>>
                ("products");

            return response.Data;   
        }
    }
}
