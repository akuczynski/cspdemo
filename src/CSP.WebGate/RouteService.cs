using CSP.ModuleContracts;
using GenHTTP.Modules.Layouting;
using GenHTTP.Modules.Layouting.Provider;
using GenHTTP.Modules.Security;
using GenHTTP.Modules.Webservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.WebGate
{
	internal class RouteService : IRouteService, ISingletonDependency
	{
		//private Dictionary<string, object> _routeMap;
		private LayoutBuilder _layout;

		public RouteService()
		{
		//	_routeMap = new Dictionary<string, object>();
			_layout = Layout.Create();
			_layout.Add(CorsPolicy.Permissive());
		}

		//public void AddRoute(string path, object instance)
		//{
		//	_routeMap.Add(path, instance);
		//}

		public void AddSerice<T>(string path) where T : new()
		{
			_layout.AddService<T>(path);
		}

		public LayoutBuilder GetHanlder()
		{
			return _layout;
		}

		//	public void RemoveRoute(string path) { }

		//public List<(string Path, object Service)> GetRouteMap()
		//{ 
		//	return  _routeMap.Select(x => new { x.Key, x.Value })
		//		.AsEnumerable()
		//		.Select(c => (c.Key, c.Value))
		//		.ToList();
		//}
	}

}
