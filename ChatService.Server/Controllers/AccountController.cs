using ChatService.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChatService.Server.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult PostRegister(RegisterInputModel registerInputModel)
        {
            var responose = this.userRepository.Register(registerInputModel);
            try
            {
                if (responose != null)
                {
                    return Ok(responose);
                }
                return BadRequest(responose);
            }
            catch(Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult PostLogin(LoginInputModel loginInputModel)
        {
            var response = this.userRepository.Login(loginInputModel: loginInputModel);
            try
            {
                if(response != null)
                {
                    return Ok(response);
                }

                return BadRequest(response);
            }
            catch(Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }


    }
}
