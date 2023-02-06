using CSP.Core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.Core.Query
{
	public interface IQueryDeserializer : ISingletonDependency
	{
		IQuery Deserialize(string queryName, string jsonObject);
	}
}
