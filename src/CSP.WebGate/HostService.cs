using CSP.ModuleContracts;
using GenHTTP.Engine;
using GenHTTP.Modules.Security;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.DependencyInjection;
using GenHTTP.Engine;

using GenHTTP.Modules.Layouting;
using GenHTTP.Modules.Practices;
using GenHTTP.Modules.Security;
using GenHTTP.Modules.Webservices;

namespace CSP.WebGate
{
    internal class HostService : IHostService, ITransientDependency
    {
        private readonly ILogger<HostService> _logger;
		private readonly IRouteService _routeService;

		public HostService(ILogger<HostService> logger, IRouteService routeService)
        {
            _logger = logger;
			_routeService = routeService;
		}

        public void Run()
        {
            var handler = ((RouteService)_routeService).GetHanlder();

			var hostProcess = Task.Factory.StartNew(() =>
            {
                Host.Create()
                           .Handler(handler)
                           .Defaults()
                           .Console()
#if DEBUG
                           .Development()
#endif
                           .Run();
            });

			_logger.LogDebug("Host service is running.");
        }
    }
}
