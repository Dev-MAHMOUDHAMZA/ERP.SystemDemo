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

    public async Task<bool> SaveAsync(T entity)
    {
        if (entity is not null)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> SaveRangeAsync(List<T> entities)
    {
        if (entities?.Any() == true)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        if (entity is not null)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> UpdateRangeAsync(List<T> entities)
    {
        if (entities?.Any() == true)
        {
            _context.Set<T>().UpdateRange(entities);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        if (entity is not null)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> DeleteRangeAsync(List<T> entities)
    {
        if (entities?.Any() == true)
        {
            _context.Set<T>().RemoveRange(entities);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> ExistAsync(Expression<Func<T, bool>> match)
    {
        return await _context.Set<T>().AsNoTracking().AnyAsync(match);
    }

    public async Task<T?> GetItemAsync(Expression<Func<T, bool>> match)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(match);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return id > 0 ? await _context.Set<T>().FindAsync(id) : null;
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match)
    {
        return await _context.Set<T>().AsNoTracking().Where(match).ToListAsync();
    }
    public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> match)
    {
        return _context.Set<T>().AsNoTracking().Where(match);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> match)
    {
        return await _context.Set<T>().AsNoTracking().CountAsync(match);
    }

    public IQueryable<T> GetSelectedQueryable(Expression<Func<T, bool>> match, Expression<Func<T, T>> selector)
    {
        return _context.Set<T>().AsNoTracking().Where(match).Select(selector);
    }

}
