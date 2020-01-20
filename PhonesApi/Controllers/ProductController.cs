using DbModels.Models;
using PhonesApi.Models;
using PhonesApi.Services;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhonesApi.Controllers
{
    public class ProductController : ApiController
	{
		private readonly IProductService _productService = new ProductService();

		public ProductController() { }

		public ProductController(IProductService productService) // Injection of IProductService
		{
			_productService = productService ?? throw new ArgumentNullException(nameof(productService)); 
		}

		/// <summary>
		/// Add order 
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("api/order/add")]
		public async Task<IHttpActionResult> AddOrder([FromBody]InOrder ord)
		{
			var success = await _productService.AddOrder(ord);

			if (ord == null)
			{
				return NotFound();
			}

			return Ok(success);
		}

		/// <summary>
		/// Gets all the categories
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("api/category/list")]
		public async Task<IHttpActionResult> GetAllCategories()
		{
			var categories = await _productService.GetAllCategories();

			if (categories == null)
			{
				return NotFound();
			}

			return Ok(categories);
		}

		/// <summary>
		/// Gets all the products
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("api/product/list")]
		public async Task<IHttpActionResult> GetAllProducts()
		{
			var product = await _productService.GetAllProducts();

			if (product == null)
			{
				return NotFound();
			}

			return Ok(product);
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
			var product = await _productService.GetProduct(id);

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

				foundProd = await _productService.GetProduct(product);

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
		[HttpGet]
		[Route("api/product/")]
		public async Task<IHttpActionResult> GetProduct(long id, string name, string descr)
		{
			Product foundProd;

			foundProd = await _productService.GetProduct(new Product(id, name, descr));

			if (foundProd == null)
			{
				return NotFound();
			}

			return Ok(foundProd);
		}
	}
}