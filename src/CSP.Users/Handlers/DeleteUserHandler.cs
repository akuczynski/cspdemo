using CSP.Core.Command;
using CSP.Users.Command;
using CSP.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Volo.Abp.DependencyInjection;

namespace CSP.Users.Handlers
{
	public class DeleteUserHandler : ICommandHandler<DeleteUserCommand>
	{
		public ICommandResult Execute(ICommand command)
		{
			return Execute((DeleteUserCommand) command);	
		}

		private ICommandResult Execute(DeleteUserCommand command)
		{
			var userService = new UserService();
			userService.DeleteUser(command.UserId);

			return new EmptyCommandResult();
		}
	}
}
