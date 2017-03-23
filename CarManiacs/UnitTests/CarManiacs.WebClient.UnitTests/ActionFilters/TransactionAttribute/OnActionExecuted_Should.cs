using CarManiacs.Business.Data.Contracts;
using CarManiacs.WebClient.UnitTests.Mocks;

using Moq;
using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace CarManiacs.WebClient.UnitTests.ActionFilters.TransactionAttribute
{
    [TestFixture]
    public class OnActionExecuted_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutedContext>();
            var filter = new WebClient.ActionFilters.TransactionAttribute();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => filter.OnActionExecuted(filterContextMock.Object));
        }

        [Test]
        public void CallUnitOfWorkSaveChangesOnce_WhenNoExceptionInContext()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutedContext>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var filter = new TransactionAttributeMock();
            filter.UnitOfWork = unitOfWorkMock.Object;

            //Act
            filter.OnActionExecuted(filterContextMock.Object);

            //Assert
            unitOfWorkMock.Verify(u => u.SaveChanges(), Times.Once);
        }

        [Test]
        public void NotCallUnitOfWorkSaveChanges_WhenExceptionInContext()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutedContext>();
            filterContextMock.Setup(f => f.Exception).Returns(new Exception());
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var filter = new TransactionAttributeMock();
            filter.UnitOfWork = unitOfWorkMock.Object;

            //Act
            filter.OnActionExecuted(filterContextMock.Object);

            //Assert
            unitOfWorkMock.Verify(u => u.SaveChanges(), Times.Never);
        }
    }
}
