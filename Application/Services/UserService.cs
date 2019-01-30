using System.Net;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Domain.Data.Commands.DomainModel;
using Domain.Data.Commands.Handlers;
using Domain.Data.Interfaces;
using Domain.Shared.Enums;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly UserHandler _userHandler;
        private readonly IUnitOfWork _uow;

        public UserService(
            IUserRepository userRepository,
            IConfiguration configuration,
            UserHandler userHandler,
            IUnitOfWork uow)
        {
            _userHandler = userHandler;
            _configuration = configuration;
            _userRepository = userRepository;
            _uow = uow;
        }

        public async Task<object> UserSave(UserDomainModel command)
        {
            try
            {
                var result = await Task.FromResult(_userHandler.Handle(command));

                if (result.Equals(EnumValidate.Exist))
                    return Response("E-mail already exists", HttpStatusCode.NotAcceptable);

                if (result.Equals(EnumValidate.Invalid))
                    return Response("Invalid fields", HttpStatusCode.BadRequest);

                if (result.Equals(EnumValidate.Empty))
                    return Response("Missing fields", HttpStatusCode.BadRequest);

                _uow.Commit();

                return Response("User Save Success", HttpStatusCode.OK);
            }
            catch
            {
                return Response("Error Aplication", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<object> GetUser(SigninDomainModel command)
        {
            var result = await Task.FromResult(_userRepository.GetByEmail(command.Email));
            try
            {
                if (result == null)
                {
                    return Response("E-mail already exists", HttpStatusCode.NotAcceptable);
                }

                if (string.IsNullOrEmpty(command.Email) &&
                    string.IsNullOrEmpty(command.Password))
                {
                    return Response("Missing fields", HttpStatusCode.BadRequest);
                }

                dynamic user = new ExpandoObject();
                user.FirstName = result.FirstName;
                user.LastName = result.LastName;
                user.Email = result.Email;

                dynamic phone = new ExpandoObject();
                var phones = new List<ExpandoObject>();

                foreach (var item in result.Phones)
                {
                    phone.Number = item.Number;
                    phone.Area_Code = item.Code;
                    phone.Country = item.Country;
                    phones.Add(phone);
                }

                user.Phones = phones;

                return Response("User Logged Success", HttpStatusCode.OK, user);
            }
            catch
            {
                return Response("Error Aplication", HttpStatusCode.InternalServerError);
            }
        }

        private static object Response(string message, HttpStatusCode status, object result)
        {
            return new
            {
                Message = message,
                StatusCode = status,
                Data = result
            };
        }

        private static object Response(string message, HttpStatusCode status)
        {
            return new
            {
                Message = message,
                StatusCode = status
            };
        }
    }
}
