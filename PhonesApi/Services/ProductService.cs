using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using DbModels.Models;
using DbProvides;

namespace PhonesApi.Services
{
	public class ProductService : IProductService
	{
		private IShopContext _context = new ShopContext();

		#region Constructors
		public ProductService() { }

		public ProductService(IShopContext context)
		{
			_context = context;
		}
		#endregion

		public Task<List<Product>> GetAllProducts()
		{
			return _context.Products.ToListAsync(); 
		}

		public Task<Product> GetProduct(long id)
		{
			return _context.Products.SingleOrDefaultAsync(o => o.Id == id);
		}

		public Task<Product> GetProduct([FromUri] Product p)
		{
			return _context.Products.SingleOrDefaultAsync(o => o.Id == p.Id
					&& o.Name == p.Name && o.Description == p.Description);
		}
	}
}
