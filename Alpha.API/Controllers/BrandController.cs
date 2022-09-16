using Alpha.Core.Dtos.Brand;
using Alpha.Core.ServiceCore;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.API.Controllers;

public class BrandController : AlphaBaseController
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _brandService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _brandService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddBrandDto brand)
    {
        return CreateActionResult(await _brandService.AddAsync(brand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandDto brand)
    {
        return CreateActionResult(await _brandService.UpdateAsync(brand));
    }
}