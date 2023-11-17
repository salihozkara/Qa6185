using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Qa6185.Web;

[Dependency(ReplaceServices = true)]
public class Qa6185BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Qa6185";
}
