using CSP.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.MobileWebGate
{
	public class CommandSerializer : ISingletonDependency, ICommandSerializer 
	{
		private readonly IEnumerable<ICommandDeserializer> _commandDeserializers;

		public CommandSerializer(IEnumerable<ICommandDeserializer> commandDeserializers)
		{
			_commandDeserializers = commandDeserializers;
		}

		public ICommand Deserialize(string commandName, string jsonObject)
		{
			foreach(var commandDeserializer in _commandDeserializers)
			{
				var result = commandDeserializer.Deserialize(commandName, jsonObject); 
				if (result != null)
				{
					return result;
				}
			}

			return null;
		}

		public string Serialize(object command)
		{
			 return JsonSerializer.Serialize(command);
		}
	}
}
