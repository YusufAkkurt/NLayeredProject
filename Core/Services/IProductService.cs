using Core.Models;

namespace Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int id);
    }
}
