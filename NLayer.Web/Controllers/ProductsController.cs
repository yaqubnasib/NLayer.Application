using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Web.Models;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApiService _apiService;

        public ProductsController(ProductApiService apiService)
        {
            this._apiService = apiService;
        }

        public IActionResult ProductsWithCategory()
        {
            var result = new List<ProductWithCategoryDto>()
            { new ProductWithCategoryDto
            {
                Id = 1,
                Name = "HP",
                Price = 5000,
                CreatedDate = DateTime.Now,
                Category = new CategoryDto(){ Id = 1, Name = "AAA"}
            },new ProductWithCategoryDto
            {
                Id = 2,
                Name = "Object",
                Price = 1000,
                CreatedDate = DateTime.Now,
                Category = new CategoryDto(){ Id = 2, Name = "BBB"}
            },new ProductWithCategoryDto
            {
                Id = 3,
                Name = "epson",
                Price = 2500,
                CreatedDate = DateTime.Now,
                Category = new CategoryDto(){ Id = 3, Name = "CCC"}
            },new ProductWithCategoryDto
            {
                Id = 4,
                Name = "Intel",
                Price = 15000,
                CreatedDate = DateTime.Now,
                Category = new CategoryDto(){ Id = 4, Name = "DDD"}
            } };


            return View("Products", result);
        }

        //public async Task<IActionResult> Index()
        //{
        //    ProductViewModel _viewModel = new ProductViewModel();   
        //    var result = await _apiService.GetAllAsync();

        //    _viewModel.Products = result;
        //    return View(_viewModel);    
        //}

        public async Task<IActionResult> Index()
        {
            ProductViewModel viewModel = new ProductViewModel();
            var result = await _apiService.GetProductsWithCategoryAsync();

            viewModel.ProductWithCategories = result;

            return View("index",viewModel);
        }
    }
}
