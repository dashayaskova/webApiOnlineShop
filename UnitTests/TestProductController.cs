using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using DbModels.Models;
using DbProvides;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhonesApi.Services;

namespace UnitTests
{
	[TestClass]
	public class TestProductController
	{
		protected ProductService ServiceUnderTest { get; }
		protected Mock<IShopContext> ShopContextMock { get; }
		protected Mock<DbSet<Product>> TestSetOfProducts { get; }

		public TestProductController()
		{
			ShopContextMock = new Mock<IShopContext>();
			ServiceUnderTest = new ProductService(ShopContextMock.Object);
			TestSetOfProducts = new Mock<DbSet<Product>>();

			var data = new List<Product>
			{
				new Product() { Id = 1, Name = "Product1", Description = "" },
				new Product() { Id = 2, Name = "Product2", Description = "" },
				new Product() { Id = 3, Name = "Product3", Description = "" },
			}.AsQueryable();

			TestSetOfProducts.As<IDbAsyncEnumerable<Product>>()
				.Setup(m => m.GetAsyncEnumerator())
				.Returns(new TestDbAsyncEnumerator<Product>(data.GetEnumerator()));

			TestSetOfProducts.As<IQueryable<Product>>()
				.Setup(m => m.Provider)
				.Returns(new TestDbAsyncQueryProvider<Product>(data.Provider));

			TestSetOfProducts.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
			TestSetOfProducts.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
			TestSetOfProducts.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
		}

		[TestMethod]
		public async Task GetProduct_ShouldReturnProductWithSameID()
		{
			ShopContextMock.Setup(c => c.Products).Returns(TestSetOfProducts.Object);
			var products = await ServiceUnderTest.GetAllProducts();
			Assert.AreEqual(3, products.Count);
			Assert.AreEqual("Product1", products[0].Name);
		}
	}
}
