using Application.IServices;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace ERP.Infrastructure.Services;
public class ServicesGeneric<T> : IServices<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public ServicesGeneric(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountAsync()
    {
        try
        {
            return await _context.Set<T>().AsNoTracking().CountAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> match)
    {
        try
        {
            return await _context.Set<T>().Where(match).AsNoTracking().CountAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Delete(T entity)
    {
        try
        {
            _context.Set<T>().Remove(entity);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        try
        {
            _context.Set<T>().Remove(entity);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Exist(Expression<Func<T, bool>> match)
    {
        try
        {
            var Result = _context.Set<T>().AsNoTracking().Any(match);
            if (Result)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> ExistAsync(Expression<Func<T, bool>> match)
    {
        try
        {
            var Result = await _context.Set<T>().AsNoTracking().AnyAsync(match);
            if (Result)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> ExistItemAsync(Expression<Func<T, bool>> match)
    {
        try
        {
            var Result = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(match);
            return Result!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<T> GetAll()
    {
        try
        {
            return _context.Set<T>().ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> match)
    {
        try
        {
            return _context.Set<T>().Where(match).AsNoTracking().ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync().ConfigureAwait(false);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match)
    {
        try
        {
            return await _context.Set<T>().Where(match).AsNoTracking().ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<(IEnumerable<T> entity, int Count)> GetAllCountAsync()
    {
        try
        {
            var Result = await _context.Set<T>().AsNoTracking().ToListAsync();
            return (Result, Result.Count());
        }
        catch (Exception ex)
        {
            throw ex ?? null!;
        }
    }
    public async Task<IQueryable<T>> GetAllQueryable()
    {
        try
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> match)
    {
        try
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking().Where(match);

            return query;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public IQueryable<TResult> GetSelectedQueryable<TResult>(Expression<Func<T, bool>> match, Expression<Func<T, TResult>> selector)
    {
        try
        {
            IQueryable<TResult> query = _context.Set<T>().AsNoTracking().Where(match).Select(selector);
            return query;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public IQueryable<TResult> GetSelectedQueryable<TResult>( Expression<Func<T, TResult>> selector)
    {
        try
        {
            IQueryable<TResult> query = _context.Set<T>().AsNoTracking().Select(selector);
            return query;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<TResult> GetSelectedItemData<TResult>(Expression<Func<T, bool>> match, Expression<Func<T, TResult>> selector)
    {
        try
        {
            var query =await _context.Set<T>().AsNoTracking().Where(match).Select(selector).FirstOrDefaultAsync();
            return query;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IQueryable<T>> GetAllQueryableAsync(Expression<Func<T, bool>> match)
    {
        try
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking().Where(match);
            return query;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<IQueryable<T>> GetAllQueryableAsync()
    {
        try
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            return query;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public T GetById(int id)
    {
        try
        {
            var Result = _context.Set<T>().Find(id);
            return Result!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> GetByIdAsync(int id)
    {
        try
        {
            var Result = await _context.Set<T>().FindAsync(id);
            return Result!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public T GetItem()
    {
        try
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault()!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public T GetItem(Expression<Func<T, bool>> match)
    {
        try
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(match)!;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public Task<T> GetItemAsync()
    {
        try
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefaultAsync()!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<T> GetItemAsync(Expression<Func<T, bool>> match)
    {
        try
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(match)!;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public bool Save(T entity)
    {
        try
        {
            if (entity is not null)
            {
                _context.Set<T>().Add(entity);
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> SaveAsync(T entity)
    {
        try
        {
            if (entity is not null)
            {
                _context.Set<T>().Add(entity);
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Update(T entity)
    {
        try
        {
            if (entity is not null)
            {
                _context.Set<T>().Update(entity);
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            if (entity is not null)
            {
                _context.Set<T>().Update(entity);
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<bool> UpdateRangeAsync(List<T> entities)
    {
        try
        {
            if (entities.Any())
            {
                _context.Set<T>().UpdateRange(entities);
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool AddRange(List<T> entities)
    {
        try
        {
            if (entities is not null && entities.Count > 0)
            {
                _context.Set<T>().AddRange(entities);
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task <bool> AddRangeAsync(List<T> entities)
    {
        try
        {
            if (entities is not null && entities.Count > 0)
            {
                await _context.Set<T>().AddRangeAsync(entities);
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool RemoveRange(List<T> entities)
    {
        try
        {
            if (entities is not null && entities.Count > 0)
            {
                _context.Set<T>().RemoveRange(entities);
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }
    IQueryable<T> IServices<T>.GetAllQueryable()
    {
        try
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            return query;

        }
        catch (Exception)
        {
            throw;
        }

    }
}
