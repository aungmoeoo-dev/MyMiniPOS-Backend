using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMiniPOS_Backend.RestApi.Features.Product.Model;

namespace MyMiniPOS_Backend.RestApi.Features.Product;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private ProductService _productService;

	public ProductController()
	{
		_productService = new ProductService();
	}

	[HttpPost]
	public async Task<IActionResult> CreateProduct([FromBody] ProductModel requestModel)
	{
		var responseModel = await _productService.CreateProduct(requestModel);

		if (!responseModel.IsSuccessful) return BadRequest(responseModel);

		return Created("this is url", responseModel);
	}

	public async Task<IActionResult> GetProducts([FromQuery] int page, int limit)
	{
		var products = await _productService.GetProducts(page, limit);

		return Ok(products);
	}
}
