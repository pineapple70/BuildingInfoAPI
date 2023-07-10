using Microsoft.EntityFrameworkCore;

namespace BuildingInfoAPI.Models
{
	public class BuildingContext : DbContext
	{
		public BuildingContext(DbContextOptions<BuildingContext> dbContext) : base(dbContext)
		{
		}

		public DbSet<BuildingInfo> BuildingInfo { get; set; } = null!;
	}
}
