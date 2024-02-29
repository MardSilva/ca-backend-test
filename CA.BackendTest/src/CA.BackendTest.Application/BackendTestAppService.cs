using System;
using System.Collections.Generic;
using System.Text;
using CA.BackendTest.Localization;
using Volo.Abp.Application.Services;

namespace CA.BackendTest;

/* Inherit your application services from this class.
 */
public abstract class BackendTestAppService : ApplicationService
{
    protected BackendTestAppService()
    {
        LocalizationResource = typeof(BackendTestResource);
    }
}
