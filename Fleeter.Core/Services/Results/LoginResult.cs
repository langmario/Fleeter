using Fleeter.Core.Models;
using Fleeter.Core.Services.Results;
using System.Runtime.Serialization;

namespace Fleeter.Core.Services
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public User? User { get; set; }
        public string? Message { get; set; }
    }
}