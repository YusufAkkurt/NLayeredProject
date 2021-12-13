using Core.Models;

namespace Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int id);
    }
}
