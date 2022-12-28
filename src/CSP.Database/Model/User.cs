using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Users.Contract
{
	public class User
	{

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public User() { }

		public User(int id, string firstName, string lastName)
		{
			ID = id;
			FirstName = firstName;
			LastName = lastName;
		}
	};
}
