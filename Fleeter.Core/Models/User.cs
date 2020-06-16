using Fleeter.Core.Database;
using System.Runtime.Serialization;

namespace Fleeter.Core.Models
{
    [DataContract]
    public class User : ISearchableEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; } = string.Empty;
        [DataMember]
        public string? Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        [DataMember]
        public bool IsAdmin { get; set; }

        [DataMember]
        public int Version { get; set; }
    }
}
