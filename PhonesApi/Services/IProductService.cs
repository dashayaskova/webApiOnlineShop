using DbModels.Models;
using PhonesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhonesApi.Services
{
	public interface IProductService
	{
		Task<List<Product>> GetAllProducts();
		Task<Product> GetProduct(long id);
		Task<Product> GetProduct([FromUri]Product product);
		Task<List<Category>> GetAllCategories();
		Task<Order> AddOrder([FromUri]InOrder order);
	}
}
