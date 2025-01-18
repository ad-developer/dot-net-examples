using System.Linq.Expressions;

namespace BaseRepositoryWithUnitOfWork;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    
    Task<IEnumerable<TEntity>> GetAllPagedAsync(int pageNumber, int pageSize);
    
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    
    Task<IEnumerable<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize);
    
    Task<TEntity> GetByIdAsync(int id);
    
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    
   IEnumerable<TEntity> GetAll();
    
    IEnumerable<TEntity> GetAllPaged(int pageNumber, int pageSize);
    
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    
    IEnumerable<TEntity> GetPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize);
    
    TEntity GetById(int id);
    
    TEntity Add(TEntity entity);
    
    TEntity Update(TEntity entity);
    
    void Delete(int id);
}