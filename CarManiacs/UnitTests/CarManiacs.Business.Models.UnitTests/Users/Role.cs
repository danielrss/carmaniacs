using NUnit.Framework;

namespace CarManiacs.Business.Models.UnitTests.Users
{
    [TestFixture]
    public class Role
    {
        [Test]
        public void ShouldHaveParameterlessConstructor()
        {
            //Arrange & Act && Assert
            Assert.IsInstanceOf<Models.Users.Role>(new Models.Users.Role());
        }

        [Test]
        public void ShouldHaveConstructorWithNameParameter()
        {
            //Arrange && Act && Assert
            Assert.IsInstanceOf<Models.Users.Role>(new Models.Users.Role("someRandomRole"));
        }

        [TestCase("rooleeTeest123")]
        [TestCase("someRandomRoleDescription")]
        public void RoleDescription_ShouldBeSetAndGottenCorrectly(string description)
        {
            //Arrange & Act
            var role = new Models.Users.Role { Description = description };

            //Assert
            Assert.AreEqual(description, role.Description);
        }
    }
}
