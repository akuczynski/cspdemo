using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CSP.EntityFrameworkCore;
using CSP.Localization;
using CSP.MultiTenancy;
using OpenIddict.Validation.AspNetCore;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using CSP.Settings;
using CSP.Data;
using System.Threading.Tasks;
using Acme.MyConsoleApp;
using Microsoft.Extensions.Logging;

namespace CSP.ASPWebGate
{
	[DependsOn(
	typeof(CSPApplicationModule),
	typeof(CSPEntityFrameworkCoreModule),
	typeof(CSPHttpApiModule),
	typeof(AbpAutofacModule),
	typeof(AbpSwashbuckleModule),
	typeof(AbpAspNetCoreSerilogModule),
	typeof(AbpAccountWebOpenIddictModule)
	)]
	public class AspWebGateModule : AbpModule
	{
		public override void PreConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
			{
				options.AddAssemblyResource(
					typeof(CSPResource),
					typeof(CSPDomainModule).Assembly,
					typeof(CSPDomainSharedModule).Assembly,
					typeof(CSPApplicationModule).Assembly,
					typeof(CSPApplicationContractsModule).Assembly
				);
			});

			PreConfigure<OpenIddictBuilder>(builder =>
			{
				builder.AddValidation(options =>
				{
					options.AddAudiences("CSP");
					options.UseLocalServer();
					options.UseAspNetCore();
				});
			});
		}

		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			var hostingEnvironment = context.Services.GetHostingEnvironment();
			var configuration = context.Services.GetConfiguration();

			ConfigureAuthentication(context);
			ConfigureUrls(configuration);
			ConfigureAutoMapper();
			ConfigureVirtualFileSystem(hostingEnvironment);
			ConfigureLocalizationServices();
			ConfigureSwaggerServices(context.Services);
			ConfigureAutoApiControllers();
		}

		private void ConfigureAuthentication(ServiceConfigurationContext context)
		{
			context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
		}

		private void ConfigureUrls(IConfiguration configuration)
		{
			Configure<AppUrlOptions>(options =>
			{
				options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
				options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"].Split(','));
			});
		}

		private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
		{
			if (hostingEnvironment.IsDevelopment())
			{
				Configure<AbpVirtualFileSystemOptions>(options =>
				{
					options.FileSets.ReplaceEmbeddedByPhysical<CSPDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}CSP.Domain.Shared"));
					options.FileSets.ReplaceEmbeddedByPhysical<CSPDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}CSP.Domain"));
					options.FileSets.ReplaceEmbeddedByPhysical<CSPApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}CSP.Application.Contracts"));
					options.FileSets.ReplaceEmbeddedByPhysical<CSPApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}CSP.Application"));
				});
			}
		}

		private void ConfigureLocalizationServices()
		{
			Configure<AbpLocalizationOptions>(options =>
			{
				options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
				options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
				options.Languages.Add(new LanguageInfo("en", "en", "English"));
				options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
				options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
				options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
				options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
				options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
				options.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
				options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
				options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
				options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
				options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
				options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
				options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
				options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
				options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
				options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
				options.Languages.Add(new LanguageInfo("es", "es", "Español"));
				options.Languages.Add(new LanguageInfo("el", "el", "Ελληνικά"));
			});
		}

		private void ConfigureSwaggerServices(IServiceCollection services)
		{
			services.AddAbpSwaggerGen(
				options =>
				{
					options.SwaggerDoc("v1", new OpenApiInfo { Title = "CSP API", Version = "v1" });
					options.DocInclusionPredicate((docName, description) => true);
					options.CustomSchemaIds(type => type.FullName);
				}
			);
		}

		private void ConfigureAutoApiControllers()
		{
			Configure<AbpAspNetCoreMvcOptions>(options =>
			{
				options.ConventionalControllers.Create(typeof(CSPApplicationModule).Assembly);
			});
		}

		private void ConfigureAutoMapper()
		{
			Configure<AbpAutoMapperOptions>(options =>
			{
				options.AddMaps<AspWebGateModule>();
			});
		}

		public override async void OnApplicationInitialization(ApplicationInitializationContext context)
		{
			var env = context.GetEnvironment();
			var app = context.GetApplicationBuilder();

			app.UseAbpRequestLocalization();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseCorrelationId();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAbpOpenIddictValidation();

			if (MultiTenancyConsts.IsEnabled)
			{
				app.UseMultiTenancy();
			}

			
			//TODO: remove this from production code 
			await ApplyMigrations(context); 

			app.UseUnitOfWork();
			app.UseAuthorization();
			app.UseSwagger();
			app.UseAbpSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "CSP API");
			});
			app.UseConfiguredEndpoints();

			// logger 
			var logger = context.ServiceProvider.GetRequiredService<ILogger<AspWebGateModule>>();
			var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
			logger.LogInformation($"MySettingName => {configuration["MySettingName"]}");

			var hostEnvironment = context.ServiceProvider.GetRequiredService<IHostEnvironment>();
			logger.LogInformation($"EnvironmentName => {hostEnvironment.EnvironmentName}");
		}

		private async Task ApplyMigrations(ApplicationInitializationContext context)
		{
			var appSettings = context.ServiceProvider.GetRequiredService<IApplicationSettings>();

			var migrationService = context.ServiceProvider.GetService<CSPDbMigrationService>();
			await migrationService.MigrateAsync();
		}
	}
}