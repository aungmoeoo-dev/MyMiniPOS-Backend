using Microsoft.EntityFrameworkCore;
using MyMiniPOS_Backend.RestApi.Features.Product.Model;
using MyMiniPOS_Backend.RestApi.Shared.Database;

namespace MyMiniPOS_Backend.RestApi.Features.Product;

public class ProductService
{
	private AppDbContext _db;

	public ProductService()
	{
		_db = new AppDbContext();
	}

	public async Task<ProductResponseModel> CreateProduct(ProductModel requestModel)
	{
		requestModel.Id = Guid.NewGuid().ToString();
		_db.Products.Add(requestModel);
		int result = await _db.SaveChangesAsync();

		string message = result > 0 ? "Saving successful." : "Saving failed.";

		ProductResponseModel responseModel = new()
		{
			IsSuccessful = result > 0,
			Message = message
		};

		return responseModel;
	}

	public async Task<List<ProductModel>> GetProducts(int page, int limit)
	{
		var products = await _db.Products
			.OrderBy(x => x.Id)
			.Skip((page - 1) * limit)
			.Take(limit)
			.ToListAsync();

		return products;
	}

	public async Task<List<ProductModel>> GetProductsByCategory(int page, int limit, string category)
	{
		var products = await _db.Products
			.OrderBy(x => x.CategoryId)
			.Skip((page - 1) * limit)
			.Take(limit)
			.ToListAsync();

		return products;
	}

	public async Task<ProductModel> GetProduct(string id)
	{
		var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);

		return product!;
	}

	public async Task<ProductResponseModel> UpdateProduct(ProductModel requestModel)
	{
		ProductResponseModel responseModel = new();

		var product = await GetProduct(requestModel.Id!);

		if (product is null)
		{
			responseModel.IsSuccessful = false;
			responseModel.Message = "No data found.";
			return responseModel;
		}

		if (requestModel.Name is not null)
		{
			product.Name = requestModel.Name;
		}
		
		if (requestModel.ImageUrl is not null)
		{
			product.ImageUrl = requestModel.ImageUrl;
		}

		if (requestModel.CategoryId is not null)
		{
			product.CategoryId = requestModel.CategoryId;
		}

		if (requestModel.Price is not null)
		{
			product.Price = requestModel.Price;
		}

		if (requestModel.DiscountRate is not null)
		{
			product.DiscountRate = requestModel.DiscountRate;
		}

		_db.Entry(product).State = EntityState.Modified;
		int result = await _db.SaveChangesAsync();

		string message = result > 0 ? "Updating successful." : "Updating failed.";

		responseModel.IsSuccessful = result > 0;
		responseModel.Message = message;
		return responseModel;
	}

	public async Task<ProductResponseModel> DeleteProduct(string id)
	{
		ProductResponseModel responseModel = new();
		var product = await GetProduct(id);

		if(product is null)
		{
			responseModel.IsSuccessful = false;
			responseModel.Message = "No data found.";

			return responseModel;
		}

		_db.Entry(product).State = EntityState.Deleted;
		int result = await _db.SaveChangesAsync();

		string message = result > 0 ? "Deleting successful." : "Deleting failed.";

		responseModel.IsSuccessful = result > 0;
		responseModel.Message = message;

		return responseModel;
	}
}
