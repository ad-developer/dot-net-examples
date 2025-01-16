using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BaseRepositoryWithUnitOfWork;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity, IDisposable
{
    protected readonly IContext _context;
    
    protected readonly DbSet<TEntity> _dbSet;
    
    public BaseRepository(IContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetAllPagedAsync(int pageNumber, int pageSize)
    {
        return await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize)
    {
        return await _dbSet.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }
    
    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public virtual async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public virtual IEnumerable<TEntity> GetAllPaged(int pageNumber, int pageSize)
    {
        return _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }
    
    public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToList();
    }

    public virtual IEnumerable<TEntity> GetPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize)
    {
        return _dbSet.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }
    
    public virtual TEntity GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual TEntity Add(TEntity entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }

    public virtual void Delete(int id)
    {
        var entity = GetById(id);
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
    
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
