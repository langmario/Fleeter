using System.Security.Permissions;

namespace Fleeter.Client.Controller
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}