using Core.Repositories;

namespace Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }

        void Commit();
        Task CommitAsync();
    }
}
