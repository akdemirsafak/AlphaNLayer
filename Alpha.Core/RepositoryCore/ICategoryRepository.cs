using Alpha.Core.Entities;

namespace Alpha.Core.RepositoryCore;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category> GetCategoryWithProducts(int id);
}