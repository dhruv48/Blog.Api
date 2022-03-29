using Blog.Api.Services.Interface;
using Blog.Common.Models;
using Blog.Manager.Inteface;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        protected readonly IContactManager _contactManager;
        protected readonly IEmailService _emailService;  
        public ContactController(IContactManager contactManager , IEmailService emailService)
        {
            _contactManager = contactManager;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task Index()
       
        
        {
            UserEmailOptions userEmailOptions = new UserEmailOptions
            {
                ToEmails = new System.Collections.Generic.List<string>() { "ayushdhruv449@gmail.com" }

            };
            await  _emailService.SendEmailTest(userEmailOptions);
        }

        [HttpPost]
        public ActionResult Insert(ContactModel contactModel)
        {
            if(ModelState.IsValid)
            {
                return Ok(_contactManager.Add(contactModel));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult GetAll()
        {
            return Ok(_contactManager.GetAll());
        }
    }
}
