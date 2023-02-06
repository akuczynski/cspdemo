using CSP.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSP.Users.Command
{
	public class DeleteUserCommand : ICommand
	{
		public long UserId { get; set; }
	}

	// TODO: use attribute for serializer registration  
	public class DeleteUserCommandDeserializer : ICommandDeserializer
	{
		public ICommand Deserialize(string commandName, string jsonObject)
		{
			if (commandName == "deleteUser" && jsonObject != null)
			{
				return JsonSerializer.Deserialize<DeleteUserCommand>(jsonObject);
			}

			return null;
		}
	}
}
