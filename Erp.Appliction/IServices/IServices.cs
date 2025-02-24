using System.Linq.Expressions;

namespace Application.IServices;
public interface IServices<T> where T : class
{
    Task<bool> SaveAsync(T entity);
    bool Save(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> UpdateRangeAsync(List<T> entities);
    bool  AddRange(List<T> entities);
    Task<bool> AddRangeAsync(List<T> entities);
    bool RemoveRange(List<T> entities);
    bool Update(T entity);
    Task<bool> DeleteAsync(T entity);
    bool Delete(T entity);
    Task<bool> ExistAsync(Expression<Func<T, bool>> match);
    Task<T> ExistItemAsync(Expression<Func<T, bool>> match);
    bool Exist(Expression<Func<T, bool>> match);
    Task<T> GetByIdAsync(int id);
    T GetById(int id);
    Task<T> GetItemAsync();
    T GetItem();
    Task<T> GetItemAsync(Expression<Func<T, bool>> match);
    T GetItem(Expression<Func<T, bool>> match);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match);
    IEnumerable<T> GetAll(Expression<Func<T, bool>> match);
    IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> match);
    Task<IQueryable<T>> GetAllQueryableAsync();
    Task<IQueryable<T>> GetAllQueryableAsync(Expression<Func<T, bool>> match);
    IQueryable<T> GetAllQueryable();
    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<T, bool>> match);

    /// <summary>
    /// This function is to get list of items according to condition but with selected columns
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="match">The expression to match the condition </param>
    /// <param name="selector"> The selected columns </param>
    /// <returns></returns>
    IQueryable<TResult> GetSelectedQueryable<TResult>(Expression<Func<T, bool>> match,
        Expression<Func<T, TResult>> selector);

    /// <summary>
    /// This function is to get all entity list with selected columns 
    ///ps: no condition 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="selector"> the expression to get selected columns </param>
    /// <returns></returns>
    IQueryable<TResult> GetSelectedQueryable<TResult>(Expression<Func<T, TResult>> selector);

    /// <summary>
    /// Get one item data according to condition with selected columns
    /// PS: will get the first item that matches the condition
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="match">The expression to match the condition </param>
    /// <param name="selector"> The selected columns </param>
    /// <returns></returns>
    Task<TResult> GetSelectedItemData<TResult>(Expression<Func<T, bool>> match,
       Expression<Func<T, TResult>> selector);

}
