using System.Runtime.Serialization;

namespace Fleeter.Core.Services.Results
{
    public  class BaseResult
    {
        public Status Status { get; set; }
        public string? Message { get; set; } = string.Empty;
    }
}
