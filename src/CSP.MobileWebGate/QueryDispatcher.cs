using CSP.Core.Command;
using CSP.Core.Query;
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
    public class QueryDispatcher : IQueryDispatcher, ISingletonDependency
	{
		private JsonObjectsSerializer _querySerializer;

		private IServiceProvider _serviceProvider;

		public QueryDispatcher(JsonObjectsSerializer querySerializer, IServiceProvider serviceProvider)
		{
			_querySerializer = querySerializer;
			_serviceProvider = serviceProvider;
		}

		public string Invoke(string queryName, string jsonObject)
		{
			var query = _querySerializer.DeserializeQuery(queryName, jsonObject); 
			if (query != null)
			{
				var data = Invoke(query);
				return System.Text.Json.JsonSerializer.Serialize(data); 
			}

			return "{}";
		} 

		public object Invoke(IQuery query)
		{
			Type d1 = typeof(IQueryHandler<>);
			var queryType = query.GetType();
			var newType = d1.MakeGenericType(queryType);

			var handlerObject = _serviceProvider.GetRequiredService(newType);
			if (handlerObject != null)
			{
				return ((IQueryHandler)handlerObject).Execute(query);
			}
			else
			{
				throw new Exception($"Query doesn't have any handler {query.GetType().Name}");
			}

			return new EmptyQueryResult();

		}
	}
}
