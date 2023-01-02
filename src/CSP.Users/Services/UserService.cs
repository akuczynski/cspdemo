using System;
using System.Collections.Generic;
using CSP.ModuleContracts.Database;
using CSP.Users.Model;
using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using TodoSQLite.Data;
using Volo.Abp.DependencyInjection;

namespace CSP.Users.Services
{
    // For documentation, see: https://genhttp.org/documentation/content/webservices
    public class UserService : ITransientDependency
    {
		private BaseRepostory<User> _database;

        public UserService()
        {
            _database = new BaseRepostory<User>();
		}

		// GET http://localhost:8080/users/?page=1&pageSize=20
		[ResourceMethod]
		public IReadOnlyList<User> GetUsers(int page, int pageSize)
        {
			var task = _database.GetAllAsync();
            task.Wait();

            return task.Result; 
        }

		// GET http://localhost:8080/users/:id/
		[ResourceMethod(":id")]
        public User? GetUser(long id)
        {
			var task = _database.GetByIdAsync(id);
            task.Wait();
            return task.Result;
		}

        [ResourceMethod(RequestMethod.PUT)]
        public long AddUser(string firstName, string lastName)
        {
            var user = new User { FirstName = firstName, LastName = lastName };
            var task = _database.SaveItemAsync(user);

            task.Wait();
            return task.Result;
        }

		// POST http://localhost:8080/users/
		[ResourceMethod(RequestMethod.POST)]
        public long UpdateUser(User user)
        {
			var task = _database.SaveItemAsync(user);
            task.Wait();

            return task.Result;
        }

        [ResourceMethod(RequestMethod.DELETE, ":id")]
        public void DeleteUser(long id)
        {
            var user = _database.GetByIdAsync(id);
            if (user.Result != null)
            {
                var task = _database.DeleteAsync(user.Result);
                task.Wait();
            }
        }
    }

}
