using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace CA.BackendTest.Web;

[Dependency(ReplaceServices = true)]
public class BackendTestBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BackendTest";
}
