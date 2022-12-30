using System;
using System.Collections.Generic;
using CSP.Core.Command;
using CSP.ModuleContracts.Database;
using CSP.Users.Command;
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
            return task.Result; 
        }

		// GET http://localhost:8080/users/:id/
		[ResourceMethod(":id")]
        public User? GetUser(long id)
        {
			var result = _database.GetByIdAsync(id).Result;
			return result;
		}

        [ResourceMethod(RequestMethod.PUT)]
        public async void AddUser(string firstName, string lastName)
        {
            var user = new User { FirstName = firstName, LastName = lastName };
            await _database.SaveItemAsync(user);
        }

		// POST http://localhost:8080/users/
		[ResourceMethod(RequestMethod.POST)]
        public async Task<long> UpdateUser(User user)
        {
			return await _database.SaveItemAsync(user);
		}

        [ResourceMethod(RequestMethod.DELETE, ":id")]
        public async void DeleteUser(long id)
        {
            var user = await _database.GetByIdAsync(id);
            if (user != null)
            {
                await _database.DeleteAsync(user);
            }
        }
    }

}
