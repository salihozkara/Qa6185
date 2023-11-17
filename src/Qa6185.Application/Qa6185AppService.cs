using Qa6185.Localization;
using Volo.Abp.Application.Services;

namespace Qa6185;

/* Inherit your application services from this class.
 */
public abstract class Qa6185AppService : ApplicationService
{
    protected Qa6185AppService()
    {
        LocalizationResource = typeof(Qa6185Resource);
    }
}
