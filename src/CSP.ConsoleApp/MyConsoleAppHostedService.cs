using System.Threading;
using System.Threading.Tasks;
using CSP.ModuleContracts;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace Acme.MyConsoleApp;

public class MyConsoleAppHostedService : IHostedService
{
    private readonly IAbpApplicationWithExternalServiceProvider _abpApplication;

    public MyConsoleAppHostedService( IAbpApplicationWithExternalServiceProvider abpApplication)
    {
        _abpApplication = abpApplication;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _abpApplication.ShutdownAsync();
    }
}
