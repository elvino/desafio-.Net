using Domain.Data.Entities;
using Domain.Shared.Entities;

namespace Domain.Data.ValuesObjects
{
    public class Phone : Entity
    {
        protected Phone() { }
        public Phone(string number, string code, string country)
        {
            Number = number;
            Code = code;
            Country = country;
        }
        public string Number { get; private set; }
        public string Code { get; private set; }
        public string Country { get; private set; }
        public User User { get; set; }
    }
}
