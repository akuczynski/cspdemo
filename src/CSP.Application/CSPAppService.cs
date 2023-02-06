using System;
using System.Collections.Generic;
using System.Text;
using CSP.Localization;
using Volo.Abp.Application.Services;

namespace CSP;

/* Inherit your application services from this class.
 */
public abstract class CSPAppService : ApplicationService
{
    protected CSPAppService()
    {
        LocalizationResource = typeof(CSPResource);
    }
}
