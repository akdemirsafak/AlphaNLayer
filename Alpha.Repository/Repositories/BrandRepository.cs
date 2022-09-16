using Alpha.Core.Entities;
using Alpha.Core.RepositoryCore;
using Alpha.Repository.Context;

namespace Alpha.Repository.Repositories;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    public BrandRepository(AlphaDBContext alphaDbContext) : base(alphaDbContext)
    {
    }
}