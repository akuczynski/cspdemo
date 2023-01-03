using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSP.ASPWebGate;
using CSP.ModuleContracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;

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
		var appDir = AppDomain.CurrentDomain.BaseDirectory;
		var pluginsFolder = Path.Combine(appDir, "Modules");

		Log.Information("Starting web host.");
		var builder = WebApplication.CreateBuilder();
		builder.Host.AddAppSettingsSecretsJson()
			.UseAutofac()
			.UseSerilog();

		await builder.AddApplicationAsync<AspWebGateModule>(options =>
		{
			 //	options.PlugInSources.AddFolder(pluginsFolder);
		});

		var app = builder.Build();
		await app.InitializeApplicationAsync();
		await app.RunAsync();
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		await _abpApplication.ShutdownAsync();
	}
}
