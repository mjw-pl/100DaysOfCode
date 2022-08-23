using Bunit;

namespace Day004
{
    public class IndexPageTest
    {
        [Fact]
        public void IndexPageRendersCorrectly()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<Day003.Pages.Index>();
            var labelElement = cut.FindAll("label");
            
            // Assert
            // Second label
            labelElement[1].TextContent.MarkupMatches("Pesel:");
        }
    }
}