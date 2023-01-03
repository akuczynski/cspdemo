﻿using System;
using System.Collections.Generic;
using CSP.ModuleContracts;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace CSP.Books.Services
{
	public class BookAppService : CSPAppService, IBookAppService, ITransientDependency  
    {
		public List<Book> GetBooks(int page, int pageSize)
        { 
			// GET http://localhost:8080/books/?page=1&pageSize=20
			return new()
            {
                new Book(1, "Lord of the Rings")
            };
        }

        public Book? GetBook(int id)
        {
            // GET http://localhost:8080/books/:id/
            throw new NotImplementedException();
        }

        public Book AddBook(Book book)
        {
            // PUT http://localhost:8080/books/
            throw new NotImplementedException();
        }

        public Book? UpdateBook(Book book)
        {
            // POST http://localhost:8080/books/
            throw new NotImplementedException();
        }

        public Book? DeleteBook(int id)
        {
            // DELETE http://localhost:8080/books/:id/
            throw new NotImplementedException();
        }

    }

}
