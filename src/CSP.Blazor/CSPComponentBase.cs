using CSP.Localization;
using Volo.Abp.AspNetCore.Components;

namespace CSP.Blazor;

public abstract class CSPComponentBase : AbpComponentBase
{
    protected CSPComponentBase()
    {
        LocalizationResource = typeof(CSPResource);
    }
}
