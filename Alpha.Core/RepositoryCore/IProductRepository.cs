using Alpha.Core.Entities;

namespace Alpha.Core.RepositoryCore;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetProductsWithCategoryAndBrand();
}