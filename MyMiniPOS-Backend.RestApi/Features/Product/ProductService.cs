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
		Console.WriteLine("MyParams" + page.ToString() + limit);
		var products = await _db.Products
			.OrderBy(x => x.Id)
			.Skip((page - 1) * limit)
			.Take(limit)
			.ToListAsync();

		return products;
	}
}
