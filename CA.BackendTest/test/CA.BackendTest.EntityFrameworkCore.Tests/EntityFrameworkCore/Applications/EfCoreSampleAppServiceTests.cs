using CA.BackendTest.Samples;
using Xunit;

namespace CA.BackendTest.EntityFrameworkCore.Applications;

[Collection(BackendTestTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BackendTestEntityFrameworkCoreTestModule>
{

}
