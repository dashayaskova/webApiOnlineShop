using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DbModels.Models;
using DbProvides;
using PhonesApi.Mappers;
using PhonesApi.Models;

namespace PhonesApi.Services
{
	public class ProductService : IProductService
	{
		private IShopContext _context = new ShopContext();
		private IMapperService _mapperService = new MapperService(new OrderToOrderEntityMapper());

		#region Constructors
		public ProductService() { }

		public ProductService(IShopContext context)
		{
			_context = context;
		}

		#endregion

		public Task<List<Category>> GetAllCategories()
		{
			return _context.Categories.ToListAsync();
		}

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

		public async Task<Order> AddOrder([FromUri]InOrder order)
		{
			//TODO сделать добавление юзера, если его нету в бд
			Order dbOrder = _mapperService.Map(order);

			foreach (var productsId in order.Products)
			{
				var productInstances = await _context.ProductInstances
					.Where(o => o.ProductId == productsId.Key && o.OrderId == null)
					.Take(productsId.Value).ToListAsync();

				productInstances.ForEach(o => { o.OrderId = dbOrder.Id; o.Order = dbOrder; });
			}

			dbOrder.User = await _context.Users.FirstAsync(u => u.Username == order.Username);
			var output = _context.Orders.Add(dbOrder);
			await _context.SaveChangesAsync();

			return output;
		}
	}
}
