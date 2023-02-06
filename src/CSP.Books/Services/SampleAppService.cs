using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace CSP.Books.Services
{
	[DisableAuditing]
	public class SampleAppService : CSPAppService, ISampleAppService
	{
		private IRepository<IdentityRole, Guid> _rolesRepo;

		public SampleAppService(IRepository<IdentityRole, Guid> rolesRepository) 
		{
			_rolesRepo = rolesRepository;
		}

		public async Task<IEnumerable<string>> GetAllRolesNames()
		{
			var roles = await _rolesRepo.GetListAsync();
			return roles.Select(roles => roles.Name).ToList();
		}
	}
}
