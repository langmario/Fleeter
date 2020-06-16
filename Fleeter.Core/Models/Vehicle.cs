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
    public class Vehicle : ISearchableEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string LicensePlate { get; set; } = string.Empty;

        [DataMember]
        public string Brand { get; set; } = string.Empty;

        [DataMember]
        public string Model { get; set; } = string.Empty;

        [DataMember]
        public decimal Insurance { get; set; }

        [DataMember]
        public DateTime LeasingFrom { get; set; }

        [DataMember]
        public DateTime LeasingTo { get; set; }

        [DataMember]
        public decimal LeasingRate { get; set; }

        public int Version { get; set; }
    }
}
