using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DbModels.Models
{
	public class User
	{
		[IgnoreDataMember]
		private List<Order> _orders;

		[DataMember]
		private string _username;

		[DataMember]
		private string _phoneNumber;

		[DataMember]
		private string _email;

		[DataMember]
		private string _password;

		public List<Order> Orders { get => _orders; set => _orders = value; }
		public string Username { get => _username; set => _username = value; }
		public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
		public string Email { get => _email; set => _email = value; }
		public string Password { get => _password; set => _password = value; }

		public User()
		{
		}

		public User(string username)
		{
			_username = username;
		}
	}
}
