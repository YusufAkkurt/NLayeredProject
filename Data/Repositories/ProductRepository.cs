using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
            return await _dbContext.Products.Include(p => p.Category).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
