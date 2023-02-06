using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace CSP.ModuleContracts
{
	public interface IBookAppService : IApplicationService
	{
		Task<IEnumerable<Book>> GetBooks(int page, int pageSize);
	}
}
