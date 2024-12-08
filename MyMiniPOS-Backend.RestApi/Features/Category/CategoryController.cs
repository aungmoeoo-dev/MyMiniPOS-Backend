using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMiniPOS_Backend.RestApi.Features.Category.Model;
using MyMiniPOS_Backend.RestApi.Shared.Model;

namespace MyMiniPOS_Backend.RestApi.Features.Category;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
	private CategoryService _categoryService;
	public CategoryController() 
	{
		_categoryService = new CategoryService();
	}

	[HttpPost]
	public async Task<IActionResult> CreateCategory([FromBody] CategoryModel requestModel)
	{
		var responseModel = await _categoryService.CreateCategory(requestModel);

		if(!responseModel.IsSuccessful) return BadRequest(responseModel);

		return Created("", responseModel);
	}

	[HttpGet]
	public async Task<IActionResult> GetCategories([FromQuery] PaginationModel paginationModel)
	{
		var responseModel = await _categoryService.GetCategories(paginationModel);

		if (!responseModel.IsSuccessful) return BadRequest(responseModel);

		return Ok(responseModel);
	}

	[HttpGet("{categoryCode}")]
	public async Task<IActionResult> GetCategory(string categoryCode)
	{
		var responseModel = await _categoryService.GetCategory(categoryCode);

		if (!responseModel.IsSuccessful) return BadRequest(responseModel);

		return Ok(responseModel);
	}

	[HttpPatch("{categoryCode}")]
	public async Task<IActionResult> UpdateCategory(string categoryCode, [FromBody] CategoryModel requestModel)
	{
		requestModel.Code = categoryCode;
		var responseModel = await _categoryService.UpdateCategory(requestModel);

		if (!responseModel.IsSuccessful) return BadRequest(responseModel);

		return Ok(responseModel);
	}
}
