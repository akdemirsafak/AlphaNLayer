using Alpha.Core.Dtos.Products;
using Alpha.Core.ServiceCore;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.API.Controllers;

public class ProductController : AlphaBaseController
{
    private readonly IProductService _productService;


    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _productService.GetAllAsync());
    }

    [HttpGet]
    [Route("ProductsWithCategoryAndBrand")]
    public async Task<IActionResult> GetProductsWithCategoryAndBrand()
    {
        return CreateActionResult(await _productService.GetProductsWithCategoryAndBrand());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProductDto productDto)
    {
        return CreateActionResult(await _productService.AddAsync(productDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
    {
        return CreateActionResult(await _productService.UpdateAsync(updateProductDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _productService.RemoveByIdAsync(id));
    }
}