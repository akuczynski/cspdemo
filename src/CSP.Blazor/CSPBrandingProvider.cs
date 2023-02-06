using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CSP.Blazor;

[Dependency(ReplaceServices = true)]
public class CSPBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CSP";
}
