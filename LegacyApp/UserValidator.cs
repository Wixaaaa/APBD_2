using System;

namespace LegacyApp
{
    public class UserValidator : IUserValidator
    {
        public bool ValidateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;

            return now >= dateOfBirth.AddYears(21);
        }
        public bool ValidateEmail(string email)
        {
            return email.Contains("@") || email.Contains(".");
        }
        public bool ValidateName(string fisrtName, string lastName)
        {
           return !(string.IsNullOrEmpty(fisrtName) || string.IsNullOrEmpty(lastName));
        }
        public void CalculateLimit(Client client, User user, IUserCreditService userCreditService)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                user.HasCreditLimit = true;
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit * 2;
            }
            else
            {
                user.HasCreditLimit = true;
                user.CreditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            }
        }
        public bool ValidateLimit(User user)
        {
            return user.CreditLimit >= 500 || !user.HasCreditLimit;
        }
    }

}
