using Blog.Api.Authorization;
using Blog.Api.Helpers;
using Blog.Common.Models;
using Blog.Manager.Inteface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IHostEnvironment _hostingEnvironment;
        readonly IUserManager _userManager;
        readonly IJwtManager _jwtManager;

        public AuthController(IHostEnvironment hostingEnvironment, IUserManager userManager, IJwtManager jwtManager)
        {

            _userManager = userManager;
            _jwtManager = jwtManager;
            _hostingEnvironment = hostingEnvironment;
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {

            var existingUser = _userManager.FindByUserNameAsync(loginModel.UserName);


            if (existingUser != null)
            {
                var isCorrect = _userManager.CheckPassword(existingUser, loginModel.Password);

                if (isCorrect)
                {

                    var jwtToken = _jwtManager.GenerateJwtToken(existingUser);

                    var name = loginModel.UserName;
                    //var result = HttpContext.GetUserId();
                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = jwtToken,
                        Name = existingUser.Name
                        //Name = HttpContext.GetUserName()
                    });
                }
            }


            return BadRequest("Invalid authentication request");
            // We dont want to give to much information on why the request has failed for security reasons
            //return BadRequest(new AuthResult()
            //{
            //    Result = false,
            //    Errors = new List<string>(){
            //                             "Invalid authentication request"
            //                        }
            //});



        }
    }
}
