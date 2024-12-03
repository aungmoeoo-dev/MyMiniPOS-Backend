using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMiniPOS_Backend.RestApi.Features.Category.Model;

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

		if(responseModel.Status == CategoryResponseStatus.Fail) return BadRequest(responseModel);

		return Created("", responseModel);
	}
}
