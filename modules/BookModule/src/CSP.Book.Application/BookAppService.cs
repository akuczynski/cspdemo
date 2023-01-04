using CSP.Book.Localization;
using Volo.Abp.Application.Services;

namespace CSP.Book;

public abstract class BookAppService : ApplicationService
{
    protected BookAppService()
    {
        LocalizationResource = typeof(BookResource);
        ObjectMapperContext = typeof(BookApplicationModule);
    }
}
