using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using DbModels.Models;
using DbProvides;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhonesApi.Controllers;

namespace UnitTests
{
	[TestClass]
	public class TestProductController
	{
		[TestMethod]
		public async Task GetProduct_ShouldReturnProductWithSameID()
		{
			var data = new List<Product>
			{
				new Product() { Id = 1, Name = "Product1", Description = "" },
				new Product() { Id = 2, Name = "Product2", Description = "" },
				new Product() { Id = 3, Name = "Product3", Description = "" },
			}.AsQueryable();

			var mockSet = new Mock<DbSet<Product>>();
			mockSet.As<IDbAsyncEnumerable<Product>>()
				.Setup(m => m.GetAsyncEnumerator())
				.Returns(new TestDbAsyncEnumerator<Product>(data.GetEnumerator()));

			mockSet.As<IQueryable<Product>>()
				.Setup(m => m.Provider)
				.Returns(new TestDbAsyncQueryProvider<Product>(data.Provider));

			mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
			mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

			var mockContext = new Mock<IShopContext>();
			mockContext.Setup(c => c.Products).Returns(mockSet.Object);

			var service = new ProductController(mockContext.Object);
			var products = await service.GetAllProducts() as OkNegotiatedContentResult<List<Product>>;

			Assert.AreEqual(3, products.Content.Count);
			Assert.AreEqual("Product1", products.Content[0].Name);
		}
	}
}
