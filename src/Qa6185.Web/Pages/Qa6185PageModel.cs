using Qa6185.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Qa6185.Web.Pages;

public abstract class Qa6185PageModel : AbpPageModel
{
    protected Qa6185PageModel()
    {
        LocalizationResourceType = typeof(Qa6185Resource);
    }
}
