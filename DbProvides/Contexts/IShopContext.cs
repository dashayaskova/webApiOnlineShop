using DbModels.Models;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DbProvides
{
	public interface IShopContext : IDisposable
	{
		DbSet<Product> Products { get; }
		DbSet<ProductInstance> ProductInstances { get; }
		DbSet<Order> Orders { get; }
		DbSet<User> Users { get; }
		DbSet<Category> Categories { get; }
		void MarkAsModified(Product item);
		Task<int> SaveChangesAsync();
	}
}
