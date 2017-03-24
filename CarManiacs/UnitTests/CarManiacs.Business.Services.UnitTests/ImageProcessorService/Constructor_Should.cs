using CarManiacs.Business.Services.Contracts;

using ImageProcessor;
using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ImageProcessorService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateObjectOfTypeIImageProcessorService_WhenParamsAreValid()
        {
            //Arrange
            var imageFactoryMock = new Mock<ImageFactory>(MockBehavior.Strict, new object[] { false });

            //Act
            var imageProcessorService = new Services.ImageProcessorService(imageFactoryMock.Object);

            //Assert
            Assert.IsInstanceOf<IImageProcessorService>(imageProcessorService);
        }

        [Test]
        public void ThrowArgumentNullException_WhenImageFactoryIsNull()
        {
            //Arrange && Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Services.ImageProcessorService(null));
        }
    }
}
