using LegacyApp;

namespace LegacyApp_Test
{
    internal class UserServiceTests
    {
        [Fact]
        public void AddUser_Should_Return_False_When_Missing_FirstName()
        {
            //Arange
            var service = new UserService();

            //Act
            var result -service.AddUser(null, null, "kowalksi@wp.pl", new DateTime(1980, 1, 1), 1);

            //Assert
            Assert.False(result);
        }
        [Fact]


    }
}
