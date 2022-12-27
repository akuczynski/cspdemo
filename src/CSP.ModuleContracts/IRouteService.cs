using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.ModuleContracts
{
	public interface IRouteService
	{
		//	void AddRoute(string path, object instance);

		// 		List<(string Path, object Service)> GetRouteMap();

		void AddSerice<T>(string path) where T : new();
		 


	}
}
