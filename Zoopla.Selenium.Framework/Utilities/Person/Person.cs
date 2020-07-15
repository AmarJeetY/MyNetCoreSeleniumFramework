using Bogus;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Utilities.Person
{
    public class Person : IPerson
    {
        public string Password()
        {
            GeneratePersonData();
            return _user.Password;
        }

        public string EmailAddress()
        {
            GeneratePersonData();
            return _user.FirstName + "." + _user.LastName
                   + "+blacklist@" + _user.DomainName;
        }

        private User _user;
         private void GeneratePersonData()
        {
            var customUser = new Faker<User>()
                .RuleFor(user => user.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(user => user.LastName, (f, u) => f.Name.LastName())
                .RuleFor(user => user.DomainName, (f, u) => f.Internet.DomainName())
                .RuleFor(user => user.Password, (f, u) => f.Internet.Password(8));

             _user = customUser.Generate();
        }
    }
}
