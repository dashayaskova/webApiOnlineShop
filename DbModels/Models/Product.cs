
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DbModels.Models
{
	[DataContract(IsReference = true)]
	public class Product
	{
		[DataMember]
		private long _id;

		[DataMember]
		private string _name;

		[DataMember]
		private string _description;

		[IgnoreDataMember]
		private List<ProductInstance> _productInstances;

		[IgnoreDataMember]
		private List<ProductCategory> _categories;

		public long Id { get => _id; set => _id = value; }
		public string Name { get => _name; set => _name = value; }
		public string Description { get => _description; set => _description = value; }
		public List<ProductInstance> ProductInstances { get => _productInstances; set => _productInstances = value; }
		public List<ProductCategory> Categories { get => _categories; set => _categories = value; }

		public Product(long id, string name, string description)
		{
			_id = id;
			_name = name;
			_description = description;
		}

		public Product()
		{
		}
	}
}