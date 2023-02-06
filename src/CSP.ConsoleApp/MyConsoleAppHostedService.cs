using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSP.ASPWebGate;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Acme.MyConsoleApp;

public class MyConsoleAppHostedService :  IHostedService
{
	private readonly IAbpApplicationWithExternalServiceProvider _abpApplication;

	public MyConsoleAppHostedService(IAbpApplicationWithExternalServiceProvider abpApplication)
	{
		_abpApplication = abpApplication;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{ 
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _abpApplication.ShutdownAsync();
	} 
}
