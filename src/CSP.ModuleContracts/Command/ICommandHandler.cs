using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.Core.Command
{
	public interface ICommandHandler
	{
//		ICommandResult Execute(TCommand command);
		// TODO: remove this method 
		ICommandResult Execute(ICommand command);
	}

	public interface ICommandHandler<in TCommand> : ICommandHandler
		where TCommand : ICommand
    {
     //   bool CanExecute(TCommand command);

   //     ICommandResult Execute(TCommand command);
    }
}
