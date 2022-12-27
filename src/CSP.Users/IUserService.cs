using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Users.Contract
{
	public interface IUserService
	{
		List<User> GetUsers(int page, int pageSize);
	}
}
