using CSP.Core.Command;
using CSP.Core.Query;
using CSP.Users.Queries;
using CSP.Users.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CSP.Users.Handlers
{
	public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery>
	{
		public dynamic Execute(IQuery query)
		{
			var userService = new UserService();
			//	var data = userService.GetUsers(0, 10);

			var task = Task.Factory.StartNew(() => userService.GetUsers(0, 10));
			task.ConfigureAwait(false);
			return task.Result;
		}
	}
}
