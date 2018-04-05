using Newtonsoft.Json;

namespace SimpleAuth.Api.Client.Models.Request
{
    public class LoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string UserAgent { get; set; }

        public string Ip { get; set; }
    }
}
