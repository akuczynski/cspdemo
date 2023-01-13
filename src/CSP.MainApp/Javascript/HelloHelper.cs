using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.MainApp.Javascript
{
	// example was taken from here: https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-dotnet-from-javascript?view=aspnetcore-7.0#class-instance-examples
	public class HelloHelper
	{
		private IServiceProvider _serviceProvider;

		public HelloHelper(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider; 
		}

		public HelloHelper(string? name)
		{
			Name = name ?? "No Name";
		}

		public string? Name { get; set; }

		[JSInvokable]
		public string GetHelloMessage() => $"Hello, {Name}!";


		//[JSInvokable]
		//public static async Task<dynamic> ExecuteServiceCall(string serviceName, string methodName, object JSON = null)
		//{
		//	return "ok";

		//	//var sampleService = ServiceProvider.GetService<ISampleAppService>();
		//	//var dtos = await sampleService.GetAsync();

		//	//return JsonSerializer.Serialize(dtos);
		//}
	}
}
