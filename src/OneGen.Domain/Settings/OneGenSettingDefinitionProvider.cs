using Volo.Abp.Settings;

namespace OneGen.Settings;

public class OneGenSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(OneGenSettings.MySetting1));
    }
}
