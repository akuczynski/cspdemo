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
	public class AddUserHandler : ICommandHandler<AddUserCommand>
	{
		public ICommandResult Execute(ICommand command)
		{
			return Execute((AddUserCommand) command);	
		}

		private ICommandResult Execute(AddUserCommand command)
		{
			var userService = new UserService();
			userService.AddUser(command.FirstName, command.LastName);

			return new EmptyCommandResult();
		}
	}

 //	internal record AddUserCommandResult(long Id) : ICommandResult;
}
