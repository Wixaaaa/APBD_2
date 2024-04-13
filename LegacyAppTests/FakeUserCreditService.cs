using LegacyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyAppTests
{
    internal class FakeUserCreditService : IUserCreditService
    {
        private readonly Dictionary<string, int> _database =
            new Dictionary<string, int>()
            {
                {"Testuch", 200},
                {"Testuszka", 20000},
                {"Testuszek", 10000},
                {"Tester", 700},
            };
        public int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            return _database[lastName];
        }
    }
}
