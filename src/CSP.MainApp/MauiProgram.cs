using Microsoft.AspNetCore.Components.WebView.Maui;
using Volo.Abp.Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Volo.Abp;
using Volo.Abp.Modularity.PlugIns;
using CSP.ModuleContracts;

namespace CSP.MainApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			})
            .ConfigureContainer(new AbpAutofacServiceProviderFactory(new Autofac.ContainerBuilder()));

        ConfigureConfiguration(builder);

        var appDir = AppDomain.CurrentDomain.BaseDirectory;
        builder.Services.AddApplication<MainAppModule>(options =>
        {
            options.Services.ReplaceConfiguration(builder.Configuration);
            options.PlugInSources.AddFolder(Path.Combine(appDir, "..\\Modules"));
        });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        var app = builder.Build();

        app.Services.GetRequiredService<IAbpApplicationWithExternalServiceProvider>().Initialize(app.Services);

		return app;
	}

    private static void ConfigureConfiguration(MauiAppBuilder builder)
    {
        var assembly = typeof(App).GetTypeInfo().Assembly;
        builder.Configuration.AddJsonFile(new EmbeddedFileProvider(assembly), "appsettings.json", optional: false, false);
    }
}
