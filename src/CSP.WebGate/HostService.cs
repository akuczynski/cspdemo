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

        public HostService(ILogger<HostService> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
			var api = Layout.Create()
			 	.AddService<BookService>("books")
				.Add(CorsPolicy.Permissive());

            var hostProcess = Task.Factory.StartNew(() =>
            {
                Host.Create()
                           .Handler(api)
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
