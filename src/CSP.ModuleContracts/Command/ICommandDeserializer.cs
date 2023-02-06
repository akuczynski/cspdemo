using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.Core.Command
{
	public interface ICommandDeserializer : ISingletonDependency
	{
		ICommand Deserialize(string commandName, string jsonObject);
	}
}
