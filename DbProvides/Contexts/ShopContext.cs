using DbModels.Models;
using DbProvides.Configurations;
using DbProvides.Migrations;
using System.Data.Entity;

namespace DbProvides
{
	public class ShopContext : DbContext, IShopContext
	{
		public ShopContext() : base("ApplicationDbContext")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
			Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<ProductInstance> ProductInstances { get; set; }

		public DbSet<Order> Orders { get; set; }
		
		public DbSet<User> Users { get; set; }

		public DbSet<Category> Categories { get; set; }

		public void MarkAsModified(Product item)
		{
			Entry(item).State = EntityState.Modified;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ProductConfiguration());
			modelBuilder.Configurations.Add(new UserConfiguration());
			modelBuilder.Configurations.Add(new OrderConfiguration());
			modelBuilder.Configurations.Add(new ProductInstanceConfiguration());
			modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
			modelBuilder.Configurations.Add(new CategoryConfiguration());
		}
	}
}
