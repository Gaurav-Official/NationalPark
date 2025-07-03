using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationlParkAPI_2.Models;
using NationlParkAPI_2.Repository.IRepository;

namespace NationlParkAPI_2.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("register")]

        public IActionResult Register([FromBody] User user)
        {
            if(ModelState.IsValid)
            {
                var isUniqueUser = _userRepository.IsUniqueUser(user.UserName);
                if (!isUniqueUser) return BadRequest("User In Use!!!!");
                var userInfo = _userRepository.Register(user.UserName,user.Password);
                if (userInfo == null) return NotFound();
                user = userInfo;
            }
            return Ok(user);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var userInDb = _userRepository.Authenticate(user.UserName, user.Password);
            if (userInDb == null) return BadRequest("Wrong User / Pwd !!!");
            return Ok(userInDb);
        }
    }
}
