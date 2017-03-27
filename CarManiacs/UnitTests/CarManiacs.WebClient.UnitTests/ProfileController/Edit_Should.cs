using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace CarManiacs.WebClient.UnitTests.ProfileController
{
    [TestFixture]
    public class Edit_Should
    {
        [Test]
        public void ReturnViewWithModel_IfModelstateIsInvalid()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var profileController = new WebClient.Controllers.ProfileController(regularUserServiceMock.Object);

            profileController.ModelState.AddModelError("", "dummy error");

            var model = new ProfileEditViewModel();

            // Act & Assert
            profileController
                .WithCallTo(c => c.Edit(model))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }
    }
}
