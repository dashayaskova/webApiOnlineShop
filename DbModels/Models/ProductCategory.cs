using System.Runtime.Serialization;

namespace DbModels.Models
{
	[DataContract]
	public class ProductCategory
	{
		[DataMember]
		private Product _product;

		[DataMember]
		private long _productId;

		[DataMember]
		private Category _category;

		[DataMember]
		private long _categoryId;

		public Product Product { get => _product; set => _product = value; }
		public long ProductId { get => _productId; set => _productId = value; }
		public long CategoryId { get => _categoryId; set => _categoryId = value; }
		public Category Category { get => _category; set => _category = value; }
	}
}
