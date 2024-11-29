using Volo.Abp.Identity;

namespace OneGen;

public static class OneGenConsts
{
	public const string DbTablePrefix = "App";
	public const string? DbSchema = null;
	public const string? GenerationSchema = "Generation";
	public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
	public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
	public const int MaxNameLength = 256;
	public const int MaxTextLength = 64 * 1024;
}