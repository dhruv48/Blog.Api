using Blog.Common.Models;
using Blog.Manager.Inteface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public ActionResult Insert(UserModel userModel)
        {
            if(ModelState.IsValid)
            {
                
                return Ok(_userManager.AddUser(userModel , userModel.Password));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
