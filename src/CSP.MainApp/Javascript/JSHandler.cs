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
using static SQLite.SQLite3;

namespace CSP.MainApp.Javascript
{
	public class JSHandler : ISingletonDependency
	{ 
		[JSInvokable]
		public static async Task<dynamic> ExecuteServiceCall(string serviceName, string methodName, object JSON = null)
		{
			//var typeName = "CSP.Book.Samples.SampleAppService, CSP.Book.Application";
   //         var methodName2 = "GetAsync"; 

            var type = Type.GetType(serviceName);

            var sampleAppService = (dynamic) MauiProgram.ServiceProvider.GetService(type);

            MethodInfo methodInfo = type.GetMethod(methodName);
            var dtos = methodInfo.Invoke(sampleAppService, null);
			
            return JsonSerializer.Serialize(dtos);
        }
	}
}
