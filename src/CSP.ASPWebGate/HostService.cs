using CSP.ModuleContracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.ASPWebGate
{
	internal class HostService : IHostService, ITransientDependency
	{
		private readonly ILogger<HostService> _logger;

		public HostService(ILogger<HostService> logger)
		{
			_logger = logger;
		}

		public string Name => "ASPNET_HOST";

		public async Task RunAsync()
		{
			Log.Information("Starting web host.");
			var builder = WebApplication.CreateBuilder();
			builder.Host.AddAppSettingsSecretsJson()
				.UseAutofac()
				.UseSerilog();

			await builder.AddApplicationAsync<AspWebGateModule>();
			var app = builder.Build();
			await app.InitializeApplicationAsync();
			await app.RunAsync();
		}
	}
}
