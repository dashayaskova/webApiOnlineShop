using System.Runtime.Serialization;

namespace DbModels.Models
{
	[DataContract]
	public class ProductInstance
	{
		[DataMember]
		private Product _product;

		[DataMember]
		private long _productId;

		[DataMember]
		private long _code;

		[DataMember]
		private Order _order;

		[DataMember]
		private long? _orderId;

		public Product Product { get => _product; set => _product = value; }
		public long ProductId { get => _productId; set => _productId = value; }
		public long Code { get => _code; set => _code = value; }
		public Order Order { get => _order; set => _order = value; }
		public long? OrderId { get => _orderId; set => _orderId = value; }
	}
}
