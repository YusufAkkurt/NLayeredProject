using Core.Repositories;
using Core.UnitOfWorks;
using Data.Repositories;

namespace Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IProductRepository Product => _productRepository ??= new ProductRepository(_appDbContext);

        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_appDbContext);

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
