﻿using Volo.Abp.Modularity;
using Volo.Abp;
using CSP.ModuleContracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
//using CSP.Services;

namespace CSP.WebGate
{
//	[DependsOn(typeof(ServiceModule))]
	public class WebGateModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var configuraiton = context.ServiceProvider.GetService<IConfiguration>();

            var webHostInProcess = configuraiton.GetValue<bool?>("WebHostInProcess");

            if (webHostInProcess == null || webHostInProcess == true)
            {
                var hostService = context.ServiceProvider
                    .GetRequiredService<IHostService>();

                hostService.RunAsync();
            }
		}
    }
}