using CSP.ModuleContracts.Database;
using SQLite; 

namespace CSP.Users.Model
{
	public class User : IEntity
	{
		[PrimaryKey, AutoIncrement]
		public long Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
	};
}
