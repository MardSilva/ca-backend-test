using CA.BackendTest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CA.BackendTest.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BackendTestController : AbpControllerBase
{
    protected BackendTestController()
    {
        LocalizationResource = typeof(BackendTestResource);
    }
}
