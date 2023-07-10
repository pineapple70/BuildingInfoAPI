using Microsoft.EntityFrameworkCore;

namespace BuildingInfoAPI.Models
{
	public class BuildingContext : DbContext
	{
		public BuildingContext(DbContextOptions<BuildingContext> dbContext) : base(dbContext)
		{
		}

		DbSet<BuildingInfo> BuildingInfos { get; set; } = null!;
	}
}
