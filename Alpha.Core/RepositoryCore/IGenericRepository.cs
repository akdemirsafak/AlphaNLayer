using System.Linq.Expressions;

namespace Alpha.Core.RepositoryCore;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll();
    Task<T> FindAsync(int id);

    IQueryable<T> Where(Expression<Func<T, bool>> condition);
    Task<bool> AnyAsync(Expression<Func<T, bool>> condition);

    Task AddRangeAsync(IEnumerable<T> entities);
    Task AddAsync(T entity);
    void Update(T value);
    void Remove(T item);
    void RemoveRange(IEnumerable<T> entities);
}