using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository) { }

        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Product.GetWithCategoryByIdAsync(id);
        }
    }
}
