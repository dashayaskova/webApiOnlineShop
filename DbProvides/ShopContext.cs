using DbModels.Models;
using DbProvides.Configurations;
using DbProvides.Migrations;
using System.Data.Entity;

namespace DbProvides
{
	public class ShopContext : DbContext
	{
		public ShopContext() :  base("ApplicationDbContext")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
			Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<ProductInstance> ProductInstances { get; set; }

		public DbSet<Order> Orders { get; set; }
		
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ProductConfiguration());
			modelBuilder.Configurations.Add(new UserConfiguration());
			modelBuilder.Configurations.Add(new OrderConfiguration());
			modelBuilder.Configurations.Add(new ProductInstanceConfiguration());
		}
	}
}
