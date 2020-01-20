using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonesApi.Models
{
	public class InOrder
	{
		public string Username;

		public string Email;

		public string Phone;

		public Dictionary<long, int> Products;
	}
}