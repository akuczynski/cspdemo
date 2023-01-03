using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSP.ModuleContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace Acme.MyConsoleApp;

public class MyConsoleAppHostedService : IHostedService
{
	private readonly IAbpApplicationWithExternalServiceProvider _abpApplication;

	private IEnumerable<IHostService> _hostServices;

	private IConfiguration _configuration;

	public MyConsoleAppHostedService(IAbpApplicationWithExternalServiceProvider abpApplication,
									  IConfiguration configuration,
									  IEnumerable<IHostService> hostServices)
	{
		_abpApplication = abpApplication;
		_hostServices = hostServices;
		_configuration = configuration;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		var hostName = _configuration.GetValue<string>("HostName");
		var host = _hostServices.Where(x => x.Name == hostName).FirstOrDefault();
		if (host == null)
		{
			await host.RunAsync();
		}
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _abpApplication.ShutdownAsync();
	}
}
