using System;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private IUserCreditService _creditService;
        private IUserValidator _userValidator;
        private IUserDataAccess _userDataAccess;

        [Obsolete] 
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _creditService = new UserCreditService();
            _userValidator = new UserValidator();
            _userDataAccess = new UserDataAcessAdapter();
        }

        public UserService (IClientRepository clientRepository, IUserCreditService creditService, IUserValidator userValidator, IUserDataAccess userDataAccess)
        {
            _clientRepository = clientRepository;
            _creditService = creditService;
            _userValidator = userValidator;
            _userDataAccess = userDataAccess;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_userValidator.ValidateName(firstName, lastName))
            {
                return false;
            }

            if (!_userValidator.ValidateEmail(email))
            {
                return false;
            }

            if (!_userValidator.ValidateAge(dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };


            _userValidator.CalculateLimit(client, user, _creditService);
            if (_userValidator.ValidateLimit(user) == false)
            {
                return false;
            }

            _userDataAccess.AddUser(user);
            return true;
        }
    }

}
