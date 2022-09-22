using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entites;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext _context) : base(_context)
        {
        }

        public Task<Category> GetCategoryByIdWithProductsAsync(int categoryId)
        {
            var categoryWithProducts = _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == categoryId);
            return categoryWithProducts;
        }

        public Task<List<Category>> GetAllCategoriesWithProductsAsync()
        {
            var categoriesWithProducts = _context.Categories.Include(c => c.Products).ToListAsync();
            return categoriesWithProducts;
        }
    }
}
