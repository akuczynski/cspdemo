using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Core.Command
{
	public interface ICommandSerializer
	{
		string Serialize(object command);
	}

	//public interface ICommandDeserializer<out T> where T : ICommand 
	//{
	//	T Deserialize(string commandName, string jsonObject);
	//}
}
