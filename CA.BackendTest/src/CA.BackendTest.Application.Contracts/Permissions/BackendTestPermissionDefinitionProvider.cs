using CA.BackendTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CA.BackendTest.Permissions;

public class BackendTestPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BackendTestPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BackendTestPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BackendTestResource>(name);
    }
}
