using Fleeter.Core.Database;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fleeter.Core.Models
{
    [DataContract]
    public class Employee : ISearchableEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Firstname { get; set; } = string.Empty;

        [DataMember]
        public string Lastname { get; set; } = string.Empty;

        [DataMember]
        public int EmployeeNumber { get; set; }

        [DataMember]
        public string Salutation { get; set; } = string.Empty;

        [DataMember]
        public string Title { get; set; } = string.Empty;

        [DataMember]
        public BusinessUnit BusinessUnit { get; set; } = null!;

        [DataMember]
        public int Version { get; set; }

    }
}
