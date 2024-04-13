using System;

namespace LegacyApp
{
    public interface IUserValidator
    {
        bool ValidateAge(DateTime dateOfBirth);
        bool ValidateEmail(string email);
        bool ValidateName(string fisrtName, string lastName);
        bool ValidateLimit(User user);
        void CalculateLimit(Client client, User user, IUserCreditService userCreditService);

    }

}
