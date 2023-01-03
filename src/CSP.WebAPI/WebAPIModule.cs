using CSP.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace CSP.WebAPI
{
	public class WebAPIModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			ConfigureAutoApiControllers();
		}		 

		private void ConfigureAutoApiControllers()
		{
			Configure<AbpAspNetCoreMvcOptions>(options =>
			{
				options.ConventionalControllers.Create(typeof(BookModule).Assembly);
			});
		}
	}
}
