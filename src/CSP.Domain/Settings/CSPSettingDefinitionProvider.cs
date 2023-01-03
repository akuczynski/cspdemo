using Volo.Abp.Settings;

namespace CSP.Settings;

public class CSPSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CSPSettings.MySetting1));
    }
}
