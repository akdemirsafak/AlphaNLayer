using System.Linq.Expressions;
using Alpha.Core.RepositoryCore;
using Alpha.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AlphaDBContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AlphaDBContext alphaDbContext)
    {
        _dbContext = alphaDbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    public async Task<T> FindAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> condition)
    {
        return _dbSet.Where(condition);
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> condition)
    {
        return _dbSet.AnyAsync(condition);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T value)
    {
        _dbSet.Update(value);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        //_context.Entry(entity)=EntityState.Deleted;
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}