using Alpha.Core.BaseDtos;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlphaBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ApiResponseDto<T> response)
    {
        if (response.StatusCode == 204) return new ObjectResult(null) { StatusCode = response.StatusCode };

        return new ObjectResult(response) { StatusCode = response.StatusCode };
    }
}