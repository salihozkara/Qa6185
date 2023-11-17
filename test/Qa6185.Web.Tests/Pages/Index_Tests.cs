using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Qa6185.Pages;

public class Index_Tests : Qa6185WebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
