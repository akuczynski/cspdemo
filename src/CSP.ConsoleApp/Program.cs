using System;
using System.IO;
using System.Threading.Tasks;
using CSP.ASPWebGate;
using CSP.Books;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp.Modularity.PlugIns;

namespace Acme.MyConsoleApp;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        try
        {
			var appDir = AppDomain.CurrentDomain.BaseDirectory;
			var pluginsFolder = Path.Combine(appDir, "Modules");

			Log.Information("Starting web host.");
			var builder = WebApplication.CreateBuilder(args);
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
            return 0; 
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}