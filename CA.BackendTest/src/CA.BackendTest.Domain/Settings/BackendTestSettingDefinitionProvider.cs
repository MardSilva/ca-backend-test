using Volo.Abp.Settings;

namespace CA.BackendTest.Settings;

public class BackendTestSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BackendTestSettings.MySetting1));
    }
}
