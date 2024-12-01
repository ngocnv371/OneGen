using OneGen.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace OneGen.Permissions;

public class OneGenPermissionDefinitionProvider : PermissionDefinitionProvider
{
	public override void Define(IPermissionDefinitionContext context)
	{
		var myGroup = context.AddGroup(OneGenPermissions.GroupName);

		var subjects = myGroup.AddPermission(OneGenPermissions.Subjects.Default, L("Permission:Subjects"));
		subjects.AddChild(OneGenPermissions.Subjects.Create, L("Permission:Subjects.Create"));
		subjects.AddChild(OneGenPermissions.Subjects.Edit, L("Permission:Subjects.Edit"));
		subjects.AddChild(OneGenPermissions.Subjects.Delete, L("Permission:Subjects.Delete"));
	}

	private static LocalizableString L(string name)
	{
		return LocalizableString.Create<OneGenResource>(name);
	}
}