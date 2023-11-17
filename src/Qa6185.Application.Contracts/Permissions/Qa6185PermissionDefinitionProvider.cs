using Qa6185.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Qa6185.Permissions;

public class Qa6185PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(Qa6185Permissions.GroupName);

        myGroup.AddPermission(Qa6185Permissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(Qa6185Permissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(Qa6185Permissions.MyPermission1, L("Permission:MyPermission1"));

        var myEntityPermission = myGroup.AddPermission(Qa6185Permissions.MyEntities.Default, L("Permission:MyEntities"));
        myEntityPermission.AddChild(Qa6185Permissions.MyEntities.Create, L("Permission:Create"));
        myEntityPermission.AddChild(Qa6185Permissions.MyEntities.Edit, L("Permission:Edit"));
        myEntityPermission.AddChild(Qa6185Permissions.MyEntities.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Qa6185Resource>(name);
    }
}