using CA.BackendTest.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CA.BackendTest.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BackendTestPageModel : AbpPageModel
{
    protected BackendTestPageModel()
    {
        LocalizationResourceType = typeof(BackendTestResource);
    }
}
