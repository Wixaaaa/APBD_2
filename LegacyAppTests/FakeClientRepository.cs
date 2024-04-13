using LegacyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyAppTests
{
    public class FakeClientRepository : IClientRepository
    {
        private static readonly Dictionary<int, Client> Database = new Dictionary<int, Client>()
        {
            {1, new Client{ClientId = 1, Name = "Testuch", Address = "Warszawa, Testowa 13", Email = "test1@mail.pl", Type = "NormalClient"}},
            {2, new Client{ClientId = 2, Name = "Testuszka", Address = "Warszawa, Testowa 87", Email = "test2@mail.pl", Type = "VeryImportantClient"}},
            {3, new Client{ClientId = 3, Name = "Testuszek", Address = "Warszawa, Testowa 21", Email = "test3@mail.pl", Type = "ImportantClient"}},
            {4, new Client{ClientId = 4, Name = "Tester", Address = "Warszawa, Testowa 2137", Email = "test4@mail.pl", Type = "NormalClient"}},
        };
        public Client GetById(int IdClient)
        {
                return Database[IdClient];
        }
    }
}
