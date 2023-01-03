using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace CSP.ModuleContracts
{
	// an example when service interface is defined in the separate assembly 
	public interface IBookAppService : IApplicationService
	{
		List<Book> GetBooks(int page, int pageSize);
		
	//	Task<IEnumerable<IdentityRole>> GetAllRoles();
	}
}
