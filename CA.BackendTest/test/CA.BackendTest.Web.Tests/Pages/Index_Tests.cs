using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CA.BackendTest.Pages;

public class Index_Tests : BackendTestWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
