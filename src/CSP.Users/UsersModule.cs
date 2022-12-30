//using CSP.Database;
using CSP.Core.Command;
using CSP.Database;
using CSP.ModuleContracts;
using CSP.Users.Command;
using CSP.Users.Handlers;
using CSP.Users.Model;
using CSP.Users.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoSQLite.Data;
using Volo.Abp;
//using Volo.Abp.Dapper;
using Volo.Abp.Modularity;

namespace CSP.Users
{
	[DependsOn(typeof(DatabaseModule))]
	public class UsersModule : AbpModule
	{
		public override void OnPreApplicationInitialization(ApplicationInitializationContext context)
		{
			RegisterRoutePaths(context);
		}

		public async override void OnPostApplicationInitialization(ApplicationInitializationContext context)
		{
			base.OnPostApplicationInitialization(context);

			// seed 
			var configuraiton = context.ServiceProvider.GetService<IConfiguration>();
			var seedDb = configuraiton.GetValue<bool?>("SeedDatabase");
			if (seedDb != null && seedDb == true)
			{
				var database = new BaseRepostory<User>();
				var data = await database.GetAllAsync();
				if ( data.Count < 1)
				{
					var user = new User { FirstName = "Tomek", LastName = "Soyer" };
					await database.SaveItemAsync(user);
				}
			}
		}

		private void RegisterRoutePaths(ApplicationInitializationContext context)
		{
			var routeService = context.ServiceProvider.GetService<IRouteService>();
			routeService?.AddSerice<UserService>("users");
		}

		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddTransient<ICommandHandler<AddUserCommand>, AddUserHandler>();
		//	context.Services.AddTransient<ICommandHandler, AddUserHandler>();
		}
	}
}