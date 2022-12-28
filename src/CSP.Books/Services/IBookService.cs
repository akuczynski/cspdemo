using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.ModuleContracts
{
	// an example when service interface is defined in the separate assembly 
	public interface IBookService 
	{
		List<Book> GetBooks(int page, int pageSize);
	}
}
