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
	}

	public interface ICommandHandler<in TCommand> : ICommandHandler
		where TCommand : ICommand
    {
        bool CanExecute(TCommand command);

        ICommandResult Execute(TCommand command);
    }
}
