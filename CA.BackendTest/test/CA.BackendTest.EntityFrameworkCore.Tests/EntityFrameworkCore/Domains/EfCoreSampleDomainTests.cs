using CA.BackendTest.Samples;
using Xunit;

namespace CA.BackendTest.EntityFrameworkCore.Domains;

[Collection(BackendTestTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BackendTestEntityFrameworkCoreTestModule>
{

}
