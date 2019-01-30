using System.Collections.Generic;
using Domain.Data.ValuesObjects;
using Domain.Shared.Entities;

namespace Domain.Data.Entities
{
    public class User : Entity
    {
        private readonly IList<Phone> _phones;

        protected User() { }

        public User(string firstName, string lastName,
                       string email, string password)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Password = password;

            _phones = new List<Phone>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public ICollection<Phone> Phones { get; set; }

        public void SetPhones(Phone item)
        {
            _phones.Add(item);
        }

        public IList<Phone> GetPhones()
        {
            return _phones;
        }
    }
}