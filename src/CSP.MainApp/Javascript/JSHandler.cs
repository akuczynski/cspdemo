using CSP.Book.Samples;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection; 

namespace CSP.MainApp.Javascript
{
	public class JSHandler : ISingletonDependency
	{ 
		[JSInvokable]
		public static async Task<dynamic> ExecuteServiceCall(string serviceName, string methodName, object JSON = null)
		{ 
            var type = Type.GetType(serviceName);

            var sampleAppService = (dynamic) MauiProgram.ServiceProvider.GetService(type);	// use IoC here 

            MethodInfo methodInfo = type.GetMethod(methodName);
            var dtos = methodInfo.Invoke(sampleAppService, null);	// invoke service method 
			
            return JsonSerializer.Serialize(dtos.Result);			
        }
	}
}
