using Alpha.Core.Entities;
using Alpha.Core.RepositoryCore;
using Alpha.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Repository.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AlphaDBContext alphaDbContext) : base(alphaDbContext)
    {
    }

    public async Task<List<Product>> GetProductsWithCategoryAndBrand()
    {
        return await _dbContext.Products.Include(p => p.Category).Include(p => p.Brand).ToListAsync();
    }
}