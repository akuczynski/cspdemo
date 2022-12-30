using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Core.Command
{
	public interface ICommandDispatcher
	{
		ICommandResult Invoke<T>(T command) where T : ICommand;

		ICommandResult Invoke(string commandName, string jsonObject);

		ICommandResult Invoke(ICommand command);
	}
}
