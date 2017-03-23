using CarManiacs.Business.Data.Contracts;
using CarManiacs.WebClient.UnitTests.Mocks;

using Moq;
using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace CarManiacs.WebClient.UnitTests.ActionFilters.TransactionAttribute
{
    [TestFixture]
    public class OnActionExecuting_Should
    {
        private IDependencyResolver originalDependencyResolver;

        [OneTimeSetUp]
        public void SaveOriginalDependencyResolver()
        {
            this.originalDependencyResolver = DependencyResolver.Current;
        }

        [TearDown]
        public void ResetOriginalDependencyResolver()
        {
            DependencyResolver.SetResolver(this.originalDependencyResolver);
        }

        [Test]
        public void ThrowArgumentNullException_WhenDependencyResolverHasNoSetup()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutingContext>();
            var filter = new WebClient.ActionFilters.TransactionAttribute();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => filter.OnActionExecuting(filterContextMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenDependencyResolverReturnsNullForIUnitOfWork()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutingContext>();
            var filter = new WebClient.ActionFilters.TransactionAttribute();

            var dependencyResolverMock = new Mock<IDependencyResolver>();
            dependencyResolverMock.Setup(dR => dR.GetService(typeof(IEfUnitOfWork))).Returns(null);
            DependencyResolver.SetResolver(dependencyResolverMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => filter.OnActionExecuting(filterContextMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenDependencyResolverReturnsWrongTypeForIUnitOfWork()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutingContext>();
            var filter = new WebClient.ActionFilters.TransactionAttribute();

            var dependencyResolverMock = new Mock<IDependencyResolver>();
            dependencyResolverMock.Setup(dR => dR.GetService(typeof(IEfUnitOfWork))).Returns(new object());
            DependencyResolver.SetResolver(dependencyResolverMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => filter.OnActionExecuting(filterContextMock.Object));
        }

        [Test]
        public void GetAndAssignUnitOfWorkSuccessfully_WhenDependencyResolverSetupIsCorrect()
        {
            //Arrange
            var filterContextMock = new Mock<ActionExecutingContext>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var filter = new TransactionAttributeMock();

            var dependencyResolverMock = new Mock<IDependencyResolver>();
            dependencyResolverMock.Setup(dR => dR.GetService(typeof(IEfUnitOfWork))).Returns(unitOfWorkMock.Object);
            DependencyResolver.SetResolver(dependencyResolverMock.Object);

            //Act
            filter.OnActionExecuting(filterContextMock.Object);

            //Assert
            dependencyResolverMock.Verify(dR => dR.GetService(typeof(IEfUnitOfWork)), Times.Once);
            Assert.AreSame(unitOfWorkMock.Object, filter.UnitOfWork);
        }
    }
}
