using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CarManiacs.WebClient.UnitTests.HomeController
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            //Arrange
            var homeController = new WebClient.Controllers.HomeController();

            //Act & Assert
            homeController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
