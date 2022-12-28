using CSP.ModuleContracts.Database;
using SQLite; 

namespace CSP.Users.Model
{
	public class User : Entity
	{
		[PrimaryKey, AutoIncrement]
		public override long Id { get; protected set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public User() { }

		public User(int id, string firstName, string lastName)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
		}
	};
}
