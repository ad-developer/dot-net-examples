using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BaseRepositoryWithUnitOfWork;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable 
                                        where TEntity : class, IEntity 
{
    protected readonly IContext _context;
    
    protected readonly DbSet<TEntity> _dbSet;
    
    public bool SaveChanges { get; set; } = true;

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
    
    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity);
        if(SaveChanges)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        return entity;
    }
    
    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Entry(entity).State = EntityState.Modified;
        if(SaveChanges)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        return entity;
    }
    
    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id);
        _dbSet.Remove(entity);
        if(SaveChanges)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
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
        if(SaveChanges)
        {
            _context.SaveChanges();
        }
        return entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        if(SaveChanges)
        {
            _context.SaveChanges();
        }
        return entity;
    }

    public virtual void Delete(int id)
    {
        var entity = GetById(id);
        _dbSet.Remove(entity);
        if(SaveChanges)
        {
            _context.SaveChanges();
        }
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
