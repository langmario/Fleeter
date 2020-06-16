using Fleeter.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Models
{
    [DataContract]
    public class Employee : ISearchableEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; } = string.Empty;

        [DataMember]
        public string LastName { get; set; } = string.Empty;

        [DataMember]
        public int EmployeeNumber { get; set; }

        [DataMember]
        public string Salutation { get; set; } = string.Empty;

        [DataMember]
        public string Title { get; set; } = string.Empty;

        [DataMember]
        public BusinessUnit BusinessUnit { get; set; } = null!;

        public int Version { get; set; }

    }
}
