using System.Linq.Expressions;
using Alpha.Core.BaseDtos;
using Alpha.Core.RepositoryCore;
using Alpha.Core.ServiceCore;
using Alpha.Core.UnitOfWorkCore;

namespace Alpha.Service.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _genericRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GenericService(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponseDto<NoContentDto>> RemoveByIdAsync(int id)
    {
        var entity = await _genericRepository.FindAsync(id);
        _genericRepository.Remove(entity);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<NoContentDto>.Success(204);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _genericRepository.AnyAsync(expression);
    }
}