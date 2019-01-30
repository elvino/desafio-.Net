using System.Threading.Tasks;
using Application.Services.Interfaces;
using Domain.Data.Commands.DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/pitang")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("user/signup")]
        public async Task<IActionResult> Get([FromBody]UserDomainModel command)
        {
            return Json(await _userService.UserSave(command));
        }

        [HttpGet]
        [Route("user/signin")]
        public async Task<IActionResult> Get2([FromBody]SigninDomainModel command)
        {
            return Json(await _userService.GetUser(command));
        }
    }
}