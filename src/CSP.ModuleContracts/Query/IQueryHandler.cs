using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.Core.Query
{
	public interface IQueryHandler
	{
		// TODO: remove this method 
		dynamic Execute(IQuery query);
	}

	public interface IQueryHandler<in TQuery> : IQueryHandler
		where TQuery : IQuery
    {
	//	IQueryResult Execute(TQuery query);
    }
}
