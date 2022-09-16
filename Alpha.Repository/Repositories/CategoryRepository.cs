using Alpha.Core.Entities;
using Alpha.Core.RepositoryCore;
using Alpha.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AlphaDBContext alphaDbContext) : base(alphaDbContext)
    {
    }

    public async Task<Category> GetCategoryWithProducts(int id)
    {
        return await _dbContext.Categories.Include(c => c.Products).SingleOrDefaultAsync(x => x.Id == id);
    }
}