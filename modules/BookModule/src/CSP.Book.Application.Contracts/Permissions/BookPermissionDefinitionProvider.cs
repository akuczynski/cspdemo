using CSP.Book.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CSP.Book.Permissions;

public class BookPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookPermissions.GroupName, L("Permission:Book"));

        myGroup.AddPermission("Book_Get_Quote", L("Permission:Book:Get_Quote"));
        myGroup.AddPermission("Book_Get_Author", L("Permission:Book:Get_Author"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookResource>(name);
    }
}
