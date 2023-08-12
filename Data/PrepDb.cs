using PlatformService.Models;

namespace PlatformService.Data
{
	public static class PrepDb
	{
		public static void PrepPopulation(IApplicationBuilder app)
		{
			using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
			SeedData(context: serviceScope.ServiceProvider.GetService<AppDbContext>());
			// context.Database.EnsureDeleted();
			// context.Database.EnsureCreated();
		}
		private static void SeedData(AppDbContext context)
		{
			if (!context.Platforms.Any())
			{
				Console.WriteLine("--> Seeding Data...");
				context.Platforms.AddRange(
					new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
					new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
					new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
				);
				context.SaveChanges();
			}
			else
			{
				Console.WriteLine("--> We already have data");
			}
		}
	}
}