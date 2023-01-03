using CSP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CSP.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CSPController : AbpControllerBase
{
    protected CSPController()
    {
        LocalizationResource = typeof(CSPResource);
    }
}
