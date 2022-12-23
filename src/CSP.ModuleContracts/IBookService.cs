﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.ModuleContracts
{
	public interface IBookService : IHttpService
	{
		List<Book> GetBooks(int page, int pageSize);
	}
}