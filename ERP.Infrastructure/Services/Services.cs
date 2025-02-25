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


    public async Task<bool> DeleteRangeAsync(List<T> entities)
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
    
    public async Task<bool> ExistAsync(Expression<Func<T, bool>> match)
    {
        try
        {
            var result = await _context.Set<T>().AsNoTracking().AnyAsync(match);
            if (result)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> GetItemAsync(Expression<Func<T, bool>> match)
    {
        try
        {
            var result = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(match);
            return result!;
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
            var result = await _context.Set<T>().AsNoTracking().ToListAsync();
            return (result, result.Count());
        }
        catch (Exception ex)
        {
            throw ex ?? null!;
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
    public IQueryable<T> GetSelectedQueryable(Expression<Func<T, bool>> match, Expression<Func<T, T>> selector)
    {
        try
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking().Where(match).Select(selector);
            return query;
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    public async Task<T> GetByIdAsync(int id)
    {
        try
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result!;
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
    public async Task <bool> SaveRangeAsync(List<T> entities)
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
    
}
