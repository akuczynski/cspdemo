using CSP.Core.Command;
using CSP.MobileWebGate.Serialization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.MobileWebGate
{

    // check this: https://abdelmajid-baco.medium.com/cqrs-pattern-with-c-a9aff05aae3f
    public class CommandDispatcher : ICommandDispatcher, ISingletonDependency
	{
		private JsonObjectsSerializer _commandSerializer;

		private IServiceProvider _serviceProvider;

		public CommandDispatcher(JsonObjectsSerializer commandSerializer, IServiceProvider serviceProvider)
		{
			_commandSerializer = commandSerializer;
			_serviceProvider = serviceProvider; 
		}

		public ICommandResult Invoke(string commandName, string jsonObject)
		{
			var command = _commandSerializer.DeserializeCommand(commandName, jsonObject); 
			if (command != null)
			{
				return Invoke(command);
			}

			return new EmptyCommandResult();
		}

		public ICommandResult Invoke<T>(T command) where T : ICommand 
		{
			
			var handler = _serviceProvider.GetRequiredService(typeof(ICommandHandler<T>));
			if (handler != null)
			{
				((ICommandHandler<T>)handler).Execute(command);
			}
			else
			{
				throw new Exception($"Command doesn't have any handler {command.GetType().Name}");
			}

			return new EmptyCommandResult();
		}

		public ICommandResult Invoke(ICommand command)
		{
			Type d1 = typeof(ICommandHandler<>);
			var commandType = command.GetType();
			var newType = d1.MakeGenericType(commandType);

			var handlerObject = _serviceProvider.GetRequiredService(newType);
			if (handlerObject != null)
			{
				((ICommandHandler)handlerObject).Execute(command);
			}
			else
			{
				throw new Exception($"Command doesn't have any handler {command.GetType().Name}");
			}

			return new EmptyCommandResult();

		}
	}
}
