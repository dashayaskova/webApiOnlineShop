using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DbModels.Models
{
	[DataContract(IsReference = true)]
	public class Order
	{
		[DataMember]
		private long _id;

		[DataMember]
		private User _user;

		[DataMember]
		private string _userId;

		[IgnoreDataMember]
		private List<ProductInstance> _productInstances;

		public long Id { get => _id; set => _id = value; }
		public User User { get => _user; set => _user = value; }
		public string UserId { get => _userId; set => _userId = value; }
		public List<ProductInstance> ProductInstances { get => _productInstances; set => _productInstances = value; }

		public Order(long id, User user)
		{
			_id = id;
			_user = user;
			_userId = user.Username;
			ProductInstances = new List<ProductInstance>();
		}

		public Order()
		{
			ProductInstances = new List<ProductInstance>();
		}
	}
}
