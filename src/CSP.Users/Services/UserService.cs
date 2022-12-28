using System;
using System.Collections.Generic;
using CSP.ModuleContracts.Database;
using CSP.Users.Contract;
//using CSP.Users.Contract;
using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using TodoSQLite.Data;

//using GenHTTP.Modules.Webservices;
using Volo.Abp.DependencyInjection;

namespace CSP.Users.Services
{
  //  public record User (int ID, string FirstName, string LastName); 

    // For documentation, see: https://genhttp.org/documentation/content/webservices

    public class UserService : IUserService, ITransientDependency
    {
		private UserDatabase _database;

        public UserService()
        {
            _database = new UserDatabase();
		}

        [ResourceMethod]
        public List<User> GetUsers(int page, int pageSize)
        {
			List<User> result =   _database.GetItemsAsync().Result;

            // GET http://localhost:8080/users/?page=1&pageSize=20
            return new()
            {
                new User(1, "Johnny", "Deep"),
                new User(1, "Sylwester", "Stallone")

            };
        }

        //[ResourceMethod(":id")]
        //public Book? GetBook(int id)
        //{
        //    // GET http://localhost:8080/books/:id/
        //    throw new NotImplementedException();
        //}

        [ResourceMethod(RequestMethod.PUT)]
        public async Task<int> AddUser()
        {
            var database = new UserDatabase();
            var user = new User() { FirstName = "Tomek", LastName = "Soyer" };
            return await database.SaveItemAsync(user);
        }

        //[ResourceMethod(RequestMethod.POST)]
        //public Book? UpdateBook(Book book)
        //{
        //    // POST http://localhost:8080/books/
        //    throw new NotImplementedException();
        //}

        //[ResourceMethod(RequestMethod.DELETE, ":id")]
        //public Book? DeleteBook(int id)
        //{
        //    // DELETE http://localhost:8080/books/:id/
        //    throw new NotImplementedException();
        //}

    }

}
