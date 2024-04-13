using LegacyApp;

namespace LegacyAppTests
{
    public class UserServiceTests
    {
        [Fact]
        public void AddUser_Should_Return_False_When_Missing_FirstName()
        {
		//Arange
    	var service = new UserService();
	    string lastName = "Testuch";
    	DateTime birthDate = new DateTime(1980, 12, 12);
    	int clientId = 1;
    	string email = "test1!mail.pl";

    	//Act
    	var result = service.AddUser("", lastName, email, birthDate, clientId);

    	//Assert
    	Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
        {
            //Arange
            var service = new UserService();
            string firstName = "Test";
            string lastName = "Testuch";
            DateTime birthDate = new DateTime(1980, 12, 12);
            int clientId = 1;
            string email = "test1";

            //Act
            var result = service.AddUser(firstName, lastName, email, birthDate, clientId);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Missing_LasttName()
        {
            //Arange
            var service = new UserService();
            string firstName = "Test";
            DateTime birthDate = new DateTime(1980, 12, 12);
            int clientId = 1;
            string email = "test1@mail.pl";

            //Act
            var result = service.AddUser(firstName, "", email, birthDate, clientId);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Age_Below_21()
        {
            //Arange
            var service = new UserService();
            string firstName = "Joe";
            string lastName = "Drace";
            DateTime birthDate = DateTime.Now.AddYears(-18);
            int clientId = 1;
            string email = "jdrace@hotmail.com";

            //Act
            var result = service.AddUser(firstName, lastName, email, birthDate, clientId);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_When_User_Has_Credit_Limit_Under_500()
        {
            //Arange
            var userDataAccess = new UserDataAcessAdapter();
            var userValidator = new UserValidator();
            var clientRepository = new FakeClientRepository();
            var userCreditService = new FakeUserCreditService();
            var service = new UserService(clientRepository, userCreditService, userValidator, userDataAccess);
            string firstName = "Test";
            string lastName = "Testuch";
            DateTime birthDate = new DateTime(1980, 12, 12);
            int clientId = 1;
            string email = "test1@mail.pl";

            //Act
            var result = service.AddUser(firstName, lastName, email, birthDate, clientId);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_True_When_User_Is_Very_Important_Client_With_No_Limit()
        {
            //Arange
            var userDataAccess = new UserDataAcessAdapter();
            var userValidator = new UserValidator();
            var clientRepository = new FakeClientRepository();
            var userCreditService = new FakeUserCreditService();
            var service = new UserService(clientRepository, userCreditService, userValidator, userDataAccess);
            string firstName = "Test";
            string lastName = "Testuszka";
            DateTime birthDate = new DateTime(1981, 10, 10);
            int clientId = 2;
            string email = "test2@mail.pl";

            //Act
            var result = service.AddUser(firstName, lastName, email, birthDate, clientId);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddUser_Should_Return_True_When_User_Is_Important_Client()
        {
            //Arange
            var userDataAccess = new UserDataAcessAdapter();
            var userValidator = new UserValidator();
            var clientRepository = new FakeClientRepository();
            var userCreditService = new FakeUserCreditService();
            var service = new UserService(clientRepository, userCreditService, userValidator, userDataAccess);
            string firstName = "Test";
            string lastName = "Testuszek";
            DateTime birthDate = new DateTime(1991, 10, 10);
            int clientId = 3;
            string email = "test3@mail.pl";

            //Act
            var result = service.AddUser(firstName, lastName, email, birthDate, clientId);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddUser_Should_Return_True_When_User_Has_Limit_Above_500()
        {
            //Arange
            var userDataAccess = new UserDataAcessAdapter();
            var userValidator = new UserValidator();
            var clientRepository = new FakeClientRepository();
            var userCreditService = new FakeUserCreditService();
            var service = new UserService(clientRepository, userCreditService, userValidator, userDataAccess);
            string firstName = "Test";
            string lastName = "Tester";
            DateTime birthDate = new DateTime(1971, 10, 10);
            int clientId = 4;
            string email = "test4@mail.pl";

            //Act
            var result = service.AddUser(firstName, lastName, email, birthDate, clientId);

            //Assert
            Assert.True(result);
        }
    }
}