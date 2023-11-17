using Qa6185.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Qa6185.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Qa6185Controller : AbpControllerBase
{
    protected Qa6185Controller()
    {
        LocalizationResource = typeof(Qa6185Resource);
    }
}
