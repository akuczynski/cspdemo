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
		private LayoutBuilder _layout;

		public RouteService()
		{
			_layout = Layout.Create();
			_layout.Add(CorsPolicy.Permissive());
		}

		public void AddSerice<T>(string path) where T : new()
		{
			_layout.AddService<T>(path);
		}

		public LayoutBuilder GetHanlder()
		{
			return _layout;
		}
	}

}
