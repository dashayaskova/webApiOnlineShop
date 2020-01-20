using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DbModels.Models
{
	[DataContract]
	public class Category
	{
		[DataMember]
		private long _id;

		[DataMember]
		private string _name;

		[IgnoreDataMember]
		private List<ProductCategory> products;

		public List<ProductCategory> Products { get => products; set => products = value; }
		public long Id { get => _id; set => _id = value; }
		public string Name { get => _name; set => _name = value; }
	}
}
