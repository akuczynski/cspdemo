using CSP.ModuleContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

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
            _logger.LogDebug("Host service is running.");

//            throw new NotImplementedException();
        }
    }
}
