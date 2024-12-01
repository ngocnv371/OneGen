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
	public static readonly string[] SupportedImageTypes = ["image/png", "image/jpeg"];
	public const string TempStorageFolder = "temp-storage";
}