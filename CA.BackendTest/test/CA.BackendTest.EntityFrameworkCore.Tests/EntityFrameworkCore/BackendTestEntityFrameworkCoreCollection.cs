using Xunit;

namespace CA.BackendTest.EntityFrameworkCore;

[CollectionDefinition(BackendTestTestConsts.CollectionDefinitionName)]
public class BackendTestEntityFrameworkCoreCollection : ICollectionFixture<BackendTestEntityFrameworkCoreFixture>
{

}
