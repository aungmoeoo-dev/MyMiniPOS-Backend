using Microsoft.EntityFrameworkCore;
using MyMiniPOS_Backend.RestApi.Features.Category.Model;
using MyMiniPOS_Backend.RestApi.Shared.Database;
using MyMiniPOS_Backend.RestApi.Shared.Model;

namespace MyMiniPOS_Backend.RestApi.Features.Category;

public class CategoryService
{
	private AppDbContext _db;

	public CategoryService()
	{
		_db = new AppDbContext();
	}

	public async Task<ResponseModel<CategoryModel>> CreateCategory(CategoryModel requestModel)
	{
		ResponseModel<CategoryModel> responseModel = new();

		if (string.IsNullOrEmpty(requestModel.Code))
		{
			responseModel.IsSuccessful = false;
			responseModel.Message = "Category code is required.";
			responseModel.Data = null;
			return responseModel;
		}

		if (string.IsNullOrEmpty(requestModel.Name))
		{
			responseModel.IsSuccessful = false;
			responseModel.Message = "Category name is required.";
			responseModel.Data = null;
			return responseModel;
		}

		try
		{
			var alreadyExistCategory = await _db.Categories.FirstOrDefaultAsync(x => x.Code == requestModel.Code);
			if (alreadyExistCategory is not null)
			{
				responseModel.IsSuccessful = false;
				responseModel.Message = "Category already exists.";
				responseModel.Data = null;
				return responseModel;
			}

			requestModel.Id = Guid.NewGuid().ToString();
			_db.Categories.Add(requestModel);
			int result = await _db.SaveChangesAsync();

			string message = result > 0 ? "Saving successful." : "Saving failed.";

			responseModel.IsSuccessful = result > 0;
			responseModel.Message = message;
			responseModel.Data = requestModel;
		}
		catch (Exception ex)
		{
			responseModel.IsSuccessful = false;
			responseModel.Message = ex.Message;
			responseModel.Data = null;
		}

		return responseModel;
	}

	public async Task<ResponseModel<List<CategoryModel>>> GetCategories(PaginationModel paginationModel)
	{
		ResponseModel<List<CategoryModel>> responseModel = new();
		List<CategoryModel> responseData = new();

		try
		{
			responseData = await _db.Categories
			.AsNoTracking()
			.OrderBy(x => x.Code)
			.Skip((paginationModel.Page - 1) * paginationModel.Limit)
			.Take(paginationModel.Limit)
			.ToListAsync();

			responseModel.IsSuccessful = true;
			responseModel.Message = $"{responseData.Count} items found.";
			responseModel.Data = responseData;
		}
		catch (Exception ex)
		{
			responseModel.IsSuccessful = false;
			responseModel.Message = ex.Message;
			responseModel.Data = null;
		}

		return responseModel;
	}

	public async Task<ResponseModel<CategoryModel>> GetCategory(string categoryCode)
	{
		ResponseModel<CategoryModel> responseModel = new();
		CategoryModel responseData = new();

		try
		{
			responseData = await _db.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Code == categoryCode);

			if (responseData is null)
			{
				responseModel.IsSuccessful = false;
				responseModel.Message = "No data found.";
			}

			responseModel.IsSuccessful = true;
			responseModel.Message = "data found.";
			responseModel.Data = responseData;
		}
		catch (Exception ex)
		{
			responseModel.IsSuccessful = false;
			responseModel.Message = ex.Message;
			responseModel.Data = null;
		}

		return responseModel;
	}

	public async Task<ResponseModel<CategoryModel>> UpdateCategory(CategoryModel requestModel)
	{
		ResponseModel<CategoryModel> responseModel = new();

		try
		{
			var alreadyExistCategory = await _db.Categories
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Code == requestModel.Code);

			if (alreadyExistCategory is null)
			{
				responseModel.IsSuccessful = false;
				responseModel.Message = "Category does not exit.";
				responseModel.Data = null;
				return responseModel;
			}

			if (!string.IsNullOrEmpty(requestModel.Code))
			{
				alreadyExistCategory.Code = requestModel.Code;
			}

			if (!string.IsNullOrEmpty(requestModel.Name))
			{
				alreadyExistCategory.Name = requestModel.Name;
			}

			if (!string.IsNullOrEmpty(requestModel.Description))
			{
				alreadyExistCategory.Description = requestModel.Description;
			}

			_db.Entry(alreadyExistCategory).State = EntityState.Modified;
			int result = await _db.SaveChangesAsync();

			string message = result > 0 ? "Updating successful." : "Updating failed.";

			responseModel.IsSuccessful = result > 0;
			responseModel.Message = message;
			responseModel.Data = alreadyExistCategory;
		}
		catch (Exception ex)
		{
			responseModel.IsSuccessful = false;
			responseModel.Message = ex.Message;
			responseModel.Data = null;
		}

		return responseModel;
	}
}
