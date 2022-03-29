using Blog.Common.Models;
using Blog.Manager.Inteface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLetterController : ControllerBase
    {
        private readonly INewsLetterMamager _newsLetterManager;
        public NewsLetterController(INewsLetterMamager newsLetterMamager)
        {
            _newsLetterManager = newsLetterMamager;
        }
        
        [HttpPost]
        public ActionResult Insert(NewsLetterModel newsLetterModel)
        {
            if(ModelState.IsValid)
            {
                return Ok(_newsLetterManager.Add(newsLetterModel));
            }
            return BadRequest();
        }
    }
}
