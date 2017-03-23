using NUnit.Framework;

namespace CarManiacs.Business.Models.UnitTests.Users
{
    [TestFixture]
    public class User
    {
        [TestCase("uuseerTeest123")]
        [TestCase("someRandomAvatarUrl")]
        public void AvatarUrl_ShouldBeSetAndGottenCorrectly(string url)
        {
            //Arrange & Act
            var user = new Models.Users.User() { AvatarUrl = url };

            //Assert
            Assert.AreEqual(url, user.AvatarUrl);
        }
    }
}
