using DbModels.Models;
using System;
using System.Data.Entity;

namespace DbProvides
{
	public interface IShopContext : IDisposable
	{
		DbSet<Product> Products { get; }
		DbSet<ProductInstance> ProductInstances { get; }
		DbSet<Order> Orders { get; }
		DbSet<User> Users { get; }
		void MarkAsModified(Product item);
	}
}
