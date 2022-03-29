using Blog.Common.Models;
using System.Threading.Tasks;

namespace Blog.Api.Services.Interface
{
    public interface IEmailService
    {
        public Task SendEmailTest(UserEmailOptions userEmailOptions);
    }
}
