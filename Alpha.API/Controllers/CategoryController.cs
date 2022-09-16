using Alpha.Core.Dtos.Category;
using Alpha.Core.ServiceCore;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.API.Controllers;

public class CategoryController : AlphaBaseController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _categoryService.GetAllAsync());
    }

    [HttpGet("GetWithProducts/{id}")]
    public async Task<IActionResult> GetCategoryWithProductsByCategoryId(int id)
    {
        return CreateActionResult(await _categoryService.GetCategoryWithProductsAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddCategoryDto category)
    {
        return CreateActionResult(await _categoryService.AddAsync(category));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryDto category)
    {
        return CreateActionResult(await _categoryService.UpdateAsync(category));
    }
}