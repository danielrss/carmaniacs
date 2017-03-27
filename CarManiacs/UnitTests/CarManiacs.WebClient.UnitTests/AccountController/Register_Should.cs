using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CarManiacs.WebClient.UnitTests.AccountController
{
    [TestFixture]
    public class Register_Should
    {
        [Test]
        public void ReturnViewWithModel_IfModelstateIsInvalid()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var accountController = new WebClient.Controllers.AccountController(regularUserServiceMock.Object);

            accountController.ModelState.AddModelError("", "eerroorr");

            var model = new RegisterViewModel();

            // Act & Assert
            accountController
                .WithCallTo(c => c.Register(model))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }
    }
}
