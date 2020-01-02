using DbModels.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DbProvides
{
	public static class EntityWrapper
	{
		public static Task<List<Product>> GetAllProducts(ShopContext context)
		{
			return context.Products.ToListAsync();
		}

		public static Task<Product> GetProduct(ShopContext context, long id)
		{
			return context.Products.SingleOrDefaultAsync(o => o.Id == id);
		}

		public static Task<Product> GetProduct(ShopContext context, Product p)
		{
				return context.Products.SingleOrDefaultAsync(o => o.Id == p.Id 
					&& o.Name == p.Name && o.Description == p.Description);
		}
	}
}
