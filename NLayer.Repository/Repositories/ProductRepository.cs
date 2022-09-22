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
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext _context) : base(_context)
        {
        }

        public Task<List<Product>> GetProductsWithCategoryAsync()
        {
            var productsWithCategory = _context.Products.Include(x=>x.Category).ToListAsync();
            return productsWithCategory;
        }
    }
}
