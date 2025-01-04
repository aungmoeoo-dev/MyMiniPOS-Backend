using Microsoft.EntityFrameworkCore;
using MyMiniPOS_Backend.Database.Tables;

namespace MyMiniPOS_Backend.Database;

public class AppDbContext : DbContext
{

	public AppDbContext(DbContextOptions options) : base(options) { }

	public DbSet<TBLUser> Users { get; set; }
}
