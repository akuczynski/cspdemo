using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Core.Query
{
	public interface IQueryDispatcher
	{
	 //	dynamic Invoke<T>(T query) where T : IQuery;

		string Invoke(string queryName, string jsonObject);

		object Invoke(IQuery query);
	}
}
