using Domain.Data.Commands.DomainModel;
using Domain.Data.Entities;
using Domain.Data.Interfaces;
using Domain.Data.ValuesObjects;
using Domain.Shared.Contracts;
using Domain.Shared.Enums;

namespace Domain.Data.Commands.Handlers
{
    public class UserHandler : IHandler<UserDomainModel>
    {
        private readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public object Handle(UserDomainModel command)
        {
            if(string.IsNullOrEmpty(command.Email) &&
               string.IsNullOrEmpty(command.Password) &&
               string.IsNullOrEmpty(command.FirstName) &&
               string.IsNullOrEmpty(command.LastName))
                return EnumValidate.Empty;

            var user = new User(command.FirstName, command.LastName,
                command.Email, command.Password);

            var userMail = _userRepository.GetByEmail(command.Email);
            
            if (userMail != null) return EnumValidate.Exist;

            if (command.Phones != null && command.Phones.Count > 0)
            {
                command.Phones.ForEach(item => {
                    user.SetPhones(new Phone(item.Number, item.Area_Code, item.Country_Code));
                });
                user.Phones = user.GetPhones();
            }            
         
            _userRepository.Save(user);

            return EnumValidate.Success;
        }
    }
}
