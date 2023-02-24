using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
