using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository) { }

        public async Task<Category> GetWithProductsByIdAsync(int id)
        {
            return await _unitOfWork.Category.GetWithProductsByIdAsync(id);
        }
    }
}
