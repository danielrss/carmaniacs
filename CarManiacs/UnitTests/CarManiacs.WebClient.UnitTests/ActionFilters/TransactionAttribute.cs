using CarManiacs.Business.Data.Contracts;
using CarManiacs.WebClient.UnitTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace CarManiacs.WebClient.UnitTests.ActionFilters
{
    [TestFixture]
    public class TransactionAttribute
    {
        [Test]
        public void OnActionExecuting_WhenDependencyResolverReturnsNullForIUnitOfWork_ShoudThrowArgumentNullException()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutingContext>();
            var filter = new WebClient.ActionFilters.TransactionAttribute();

            var dependencyResolverMock = new Mock<IDependencyResolver>();
            dependencyResolverMock.Setup(dR => dR.GetService(typeof(IUnitOfWork))).Returns(null);
            DependencyResolver.SetResolver(dependencyResolverMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => filter.OnActionExecuting(filterContextMock.Object));
        }

        [Test]
        public void OnActionExecuting_WhenDependencyResolverReturnsWrongTypeForIUnitOfWork_ShoudThrowArgumentNullException()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutingContext>();
            var filter = new WebClient.ActionFilters.TransactionAttribute();

            var dependencyResolverMock = new Mock<IDependencyResolver>();
            dependencyResolverMock.Setup(dR => dR.GetService(typeof(IUnitOfWork))).Returns(new object());
            DependencyResolver.SetResolver(dependencyResolverMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => filter.OnActionExecuting(filterContextMock.Object));
        }

        [Test]
        public void OnActionExecuting_WhenDependencyResolverSetupIsCorrect_ShoudGetAndAssignUnitOfWorkSuccessfully()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutingContext>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var filter = new TransactionAttributeMock();

            var dependencyResolverMock = new Mock<IDependencyResolver>();
            dependencyResolverMock.Setup(dR => dR.GetService(typeof(IUnitOfWork))).Returns(unitOfWorkMock.Object);
            DependencyResolver.SetResolver(dependencyResolverMock.Object);

            //Act
            filter.OnActionExecuting(filterContextMock.Object);

            //Assert
            dependencyResolverMock.Verify(dR => dR.GetService(typeof(IUnitOfWork)), Times.Once);
            Assert.AreSame(unitOfWorkMock.Object, filter.UnitOfWork);
        }

        [Test]
        public void OnActionExecuted_WhenUnitOfWorkIsNull_ShoulThrowArgumentNullException()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutedContext>();
            var filter = new WebClient.ActionFilters.TransactionAttribute();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => filter.OnActionExecuted(filterContextMock.Object));
        }

        [Test]
        public void OnActionExecuted_WhenNoExceptionInContext_ShouldCallUnitOfWorkSaveChanges()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutedContext>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var filter = new TransactionAttributeMock();
            filter.UnitOfWork = unitOfWorkMock.Object;

            //Act
            filter.OnActionExecuted(filterContextMock.Object);

            //Assert
            unitOfWorkMock.Verify(u => u.SaveChanges(), Times.Once);
        }

        [Test]
        public void OnActionExecuted_WhenExceptionInContext_ShouldNotCallUnitOfWorkSaveChanges()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutedContext>();
            filterContextMock.Setup(f => f.Exception).Returns(new Exception());
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var filter = new TransactionAttributeMock();
            filter.UnitOfWork = unitOfWorkMock.Object;

            //Act
            filter.OnActionExecuted(filterContextMock.Object);

            //Assert
            unitOfWorkMock.Verify(u => u.SaveChanges(), Times.Never);
        }
    }
}
