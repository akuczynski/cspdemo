using CSP.Core;
using CSP.Core.Command; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace CSP.Users.Command
{
	public class AddUserCommand : ICommand
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }
	}	

	// TODO: use attribute for serializer registration  
	public class AddUserCommandDeserializer : ICommandDeserializer
	{
		public ICommand Deserialize(string commandName, string jsonObject) 
		{
			if (commandName == "addUser" && jsonObject != null)
			{
				return JsonSerializer.Deserialize<AddUserCommand>(jsonObject);
			}

			return null; 
		}
	}
}
