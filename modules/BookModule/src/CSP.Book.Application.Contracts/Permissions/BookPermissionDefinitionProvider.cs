using CSP.Book.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CSP.Book.Permissions;

public class BookPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookPermissions.GroupName, L("Permission:Book"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookResource>(name);
    }
}
