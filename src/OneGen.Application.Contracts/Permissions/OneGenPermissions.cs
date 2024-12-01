namespace OneGen.Permissions;

public static class OneGenPermissions
{
	public const string GroupName = "OneGen";

	public static class Subjects
	{
		public const string Default = GroupName + ".Subjects";
		public const string Create = Default + ".Create";
		public const string Edit = Default + ".Edit";
		public const string Delete = Default + ".Delete";
	}
}