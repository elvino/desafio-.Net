using System.Threading.Tasks;
using Domain.Data.Commands.DomainModel;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<object> UserSave(UserDomainModel command);
        Task<object> GetUser(SigninDomainModel command);
    }
}
