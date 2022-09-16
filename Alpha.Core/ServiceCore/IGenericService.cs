using System.Linq.Expressions;
using Alpha.Core.BaseDtos;

namespace Alpha.Core.ServiceCore;

public interface IGenericService<T> where T : class
{
    Task<ApiResponseDto<NoContentDto>> RemoveByIdAsync(int id);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
}