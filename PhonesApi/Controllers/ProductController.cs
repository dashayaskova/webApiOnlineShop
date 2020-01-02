using DbModels.Models;
using DbProvides;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhonesApi.Controllers
{
    public class ProductController : ApiController
	{
		/// <summary>
		/// Gets all the products
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("api/product/list")]
		public async Task<IHttpActionResult> GetAllProducts()
		{
			List<Product> list = null;

			using (var _context = new ShopContext())
			{
				list = await EntityWrapper.GetAllProducts(_context);
			}

			if (list == null)
			{
				return NotFound();
			}

			return Ok(list);
		}

		/// <summary>
		/// Get product by its id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("api/product/{id}")]
		public async Task<IHttpActionResult> GetProduct(long id)
		{
			Product product = null;

			using (var _context = new ShopContext())
			{
				product = await EntityWrapper.GetProduct(_context, id);
			}

			if (product == null)
			{
				return NotFound();
			}

			return Ok(product);
		}

		/// <summary>
		/// Get product by its object
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("api/product/")]
		public async Task<IHttpActionResult> GetProduct([FromUri]Product product)
		{
			if (product != null)
			{
				Product foundProd = null;

				using (var _context = new ShopContext())
				{
					foundProd = await EntityWrapper.GetProduct(_context, product);
				}

				if (foundProd != null)
				{
					return Ok(foundProd);
				}
			}

			return NotFound();
		}

		/// <summary>
		/// api/product?id=1&name=bla&descr=blo
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		/*[HttpGet]
		[Route("api/product/")]
		public Product GetProduct(long id, string name, string descr)
		{
			var foundProd = EntityWrapper.GetProduct(id, name, descr);

			if (foundProd == null)
			{
				return NotFound();
			}

			return Ok(foundProd);
		}*/
	}
}