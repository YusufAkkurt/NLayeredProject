using Core.Models;

namespace Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int id);
    }
}
