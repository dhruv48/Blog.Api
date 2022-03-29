

using Blog.Common.Models;

namespace Blog.Api.Authorization
{
    public interface IJwtManager
    {
        string GenerateJwtToken(UserModel userModel);
    }

}
