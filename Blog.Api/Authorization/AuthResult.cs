using System.Collections.Generic;

namespace Blog.Api.Authorization
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Result { get; set; }
        public string Name { get; set; }
        public List<string> Errors { get; set; }
    }
}
