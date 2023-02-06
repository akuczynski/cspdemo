using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Books.Services
{
	public interface ISampleAppService
	{
		Task<IEnumerable<string>> GetAllRolesNames();
	}
}
