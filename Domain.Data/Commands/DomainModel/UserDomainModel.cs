using System.Collections.Generic;

namespace Domain.Data.Commands.DomainModel
{
    public class UserDomainModel 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<PhoneDomainModel> Phones { get; set; }
        
    }

    public class PhoneDomainModel
    {
        public string Number { get; set; }
        public string Area_Code { get; set; }
        public string Country_Code { get; set; }
    }
}
