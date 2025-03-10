using System.Linq.Expressions;

namespace Application.IServices;
public interface IServices<T> where T : class
{
    Task<bool> SaveAsync(T entity);
    Task<bool> SaveRangeAsync(List<T> entities);
    Task<bool> UpdateAsync(T entity);
    Task<bool> UpdateRangeAsync(List<T> entities);
    Task<bool> DeleteAsync(T entity);
    Task<bool> DeleteRangeAsync(List<T> entities);
    Task<bool> ExistAsync(Expression<Func<T, bool>> match);
    Task<T?> GetItemAsync(Expression<Func<T, bool>> match);
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match);
    IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> match);
    Task<int> CountAsync(Expression<Func<T, bool>> match);
    Task<int> SumAsync(Expression<Func<T, bool>> match, Expression<Func<T, int>> selector);
    IQueryable<T> GetSelectedQueryable(Expression<Func<T, bool>> match,Expression<Func<T, T>> selector);
}
