using Volo.Abp.DependencyInjection;

namespace CSP.MainApp;

public class HelloWorldService : ITransientDependency
{
    public string SayHello()
    {
        return "Hello, World!";
    }
}