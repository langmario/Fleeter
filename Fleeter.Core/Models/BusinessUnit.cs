using Fleeter.Core.Database;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fleeter.Core.Models
{
    [DataContract]
    public class BusinessUnit : ISearchableEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; } = string.Empty;

        [DataMember]
        public string Description { get; set; } = string.Empty;

        [DataMember]
        public int Version { get; set; }
    }
}
