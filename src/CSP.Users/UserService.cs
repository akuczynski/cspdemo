using System;
using System.Collections.Generic;
using CSP.Users.Contract;
using GenHTTP.Api.Protocol;

using GenHTTP.Modules.Webservices;
using Volo.Abp.DependencyInjection;

namespace CSP.Users
{

    // For documentation, see: https://genhttp.org/documentation/content/webservices

    public class UserService : IUserService, ITransientDependency
	{
		public string Name => "books";

		[ResourceMethod]
        public List<User> GetUsers(int page, int pageSize)
        {
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

        //[ResourceMethod(RequestMethod.PUT)]
        //public Book AddBook(Book book)
        //{
        //    // PUT http://localhost:8080/books/
        //    throw new NotImplementedException();
        //}

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
