using Alpha.Core.BaseDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alpha.API.Filters;

public class ValidateFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage).ToList();
            context.Result = new BadRequestObjectResult(ApiResponseDto<NoContentDto>.Fail(400, errors));
        }

        base.OnActionExecuting(context);
    }
}