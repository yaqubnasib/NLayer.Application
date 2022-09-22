using NLayer.Core.DTOs;

namespace NLayer.Web.Models
{
    public class ProductViewModel
    {
        public List<ProductDto> Products { get; set; }
        public List<ProductWithCategoryDto> ProductWithCategories { get; set; }
    }
}
