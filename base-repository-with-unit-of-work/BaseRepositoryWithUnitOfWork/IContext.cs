using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BaseRepositoryWithUnitOfWork;

public interface IContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    int SaveChanges();

    Task<int> SaveChangesAsync();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    void Dispose();
}
