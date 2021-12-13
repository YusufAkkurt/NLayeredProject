using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<Category> GetWithProductsByIdAsync(int id)
        {
            return await _dbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
