using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CarManiacs.WebClient.UnitTests.AccountController
{
    [TestFixture]
    public class Login_Should
    {
        [Test]
        public void ReturnViewWithModel_IfModelstateIsInvalid()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var accountController = new WebClient.Controllers.AccountController(regularUserServiceMock.Object);

            accountController.ModelState.AddModelError("", "dummy error");

            var model = new LoginViewModel();
            string returnUrl = "returnUurrll";

            // Act & Assert
            accountController
                .WithCallTo(c => c.Login(model, returnUrl))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }
    }
}
