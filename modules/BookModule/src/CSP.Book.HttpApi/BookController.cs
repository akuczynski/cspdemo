using CSP.Book.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CSP.Book;

public abstract class BookController : AbpControllerBase
{
    protected BookController()
    {
        LocalizationResource = typeof(BookResource);
    }
}
