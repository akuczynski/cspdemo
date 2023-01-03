using CSP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CSP.Permissions;

public class CSPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CSPPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CSPPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CSPResource>(name);
    }
}
