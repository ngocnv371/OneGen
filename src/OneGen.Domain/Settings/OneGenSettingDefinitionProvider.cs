using Volo.Abp.Settings;

namespace OneGen.Settings;

public class OneGenSettingDefinitionProvider : SettingDefinitionProvider
{
	public override void Define(ISettingDefinitionContext context)
	{
		context.Add(new SettingDefinition(OneGenSettings.Imaging.MaxHeight, "2048"));
		context.Add(new SettingDefinition(OneGenSettings.Imaging.MaxWidth, "2048"));
	}
}