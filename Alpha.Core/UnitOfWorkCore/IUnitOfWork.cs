namespace Alpha.Core.UnitOfWorkCore;

public interface IUnitOfWork
{
    Task CommitAsync();
    int Commit();
}