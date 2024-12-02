using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyMiniPOS_Backend.RestApi.Features.Product.Model;

namespace MyMiniPOS_Backend.RestApi.Shared.Database;

public class AppDbContext : DbContext
{
	private readonly SqlConnectionStringBuilder _SqlConnectionStringBuilder;
	public AppDbContext()
	{
		_SqlConnectionStringBuilder = new()
		{
			DataSource = ".",
			InitialCatalog = "MyMiniPOSDB",
			UserID = "sa",
			Password = "Aa145156167!",
			TrustServerCertificate = true
		};
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(_SqlConnectionStringBuilder.ConnectionString);
	}

	public DbSet<ProductModel> Products { get; set; }
}
