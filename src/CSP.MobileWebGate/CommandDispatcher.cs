using CSP.Core.Command;
using CSP.Users.Command;
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
		private CommandSerializer _commandSerializer;

		private IServiceProvider _serviceProvider;

		public CommandDispatcher(CommandSerializer commandSerializer, IServiceProvider serviceProvider)
		{
			_commandSerializer = commandSerializer;
			_serviceProvider = serviceProvider; 
		}

		public ICommandResult Invoke(string commandName, string jsonObject)
		{
			var command = _commandSerializer.Deserialize(commandName, jsonObject); 
			if (command != null)
			{
				//Invoke<AddUserCommand>((AddUserCommand) command);
				return Invoke(command);
				//return Invoke<ICommand>(command); 
			}

			return new EmptyCommandResult();
		}

		public ICommandResult Invoke<T>(T command) where T : ICommand 
		{
			// var type = typeof(ICommandHandler<T>);
			//			var handlers = _serviceProvider.GetServices<ICommandHandler>();
			
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
				// Convert.ChangeType(handlerObject, newType);
				dynamic changedObj = handlerObject as dynamic; // Convert.ChangeType(handlerObject, newType);
				changedObj.Execute(command);

				//	var caller = (ICommandHandler<ICommand>) handler;

				//((newType) handler).Execute(command);
			}
			else
			{
				throw new Exception($"Command doesn't have any handler {command.GetType().Name}");
			}

			return new EmptyCommandResult();

		}
	}
}
