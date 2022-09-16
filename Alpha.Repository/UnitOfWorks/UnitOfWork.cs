using Alpha.Core.UnitOfWorkCore;
using Alpha.Repository.Context;

namespace Alpha.Repository.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AlphaDBContext _dbContext;

    public UnitOfWork(AlphaDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }
}