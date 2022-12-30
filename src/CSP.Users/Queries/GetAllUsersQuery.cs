using CSP.Core.Command;
using CSP.Core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.Users.Queries
{
	public class GetAllUsersQuery : IQuery
	{
	}

	// TODO: use attribute for serializer registration  
	public class GetAllUsersQueryDeserializer : IQueryDeserializer 
	{
		public IQuery Deserialize(string queryName, string jsonObject)
		{
			if (queryName == "getAllUsers") // && jsonObject != null)
			{
				return new GetAllUsersQuery(); 
			}

			return null;
		}
	}
}
