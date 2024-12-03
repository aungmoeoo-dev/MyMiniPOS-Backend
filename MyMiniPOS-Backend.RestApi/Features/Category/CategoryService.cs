using MyMiniPOS_Backend.RestApi.Features.Category.Model;
using MyMiniPOS_Backend.RestApi.Shared.Database;

namespace MyMiniPOS_Backend.RestApi.Features.Category;

public class CategoryService
{
	private AppDbContext _db;

	public CategoryService()
	{
		_db = new AppDbContext();
	}

	public async Task<CategoryResponseModel> CreateCategory(CategoryModel requestModel)
	{
		CategoryResponseModel responseModel = new();

		if (requestModel.Name is null)
		{
			responseModel.IsSuccessful = false;
			responseModel.Status = CategoryResponseStatus.Fail;
			responseModel.Message = "Require request information";

			return responseModel;
		}

		requestModel.Id = Guid.NewGuid().ToString();
		_db.Categories.Add(requestModel);
		int result = await _db.SaveChangesAsync();

		CategoryResponseStatus status =
			result > 0 ? CategoryResponseStatus.Created : CategoryResponseStatus.Fail;

		string message = result > 0 ? "Saving successful." : "Saving failed";

		responseModel.IsSuccessful = result > 0;
		responseModel.Status = status;
		responseModel.Message = message;

		return responseModel;
	}
}
