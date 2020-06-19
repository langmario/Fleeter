using Fleeter.Core.Database;
using System;
using System.Runtime.Serialization;

namespace Fleeter.Core.Models
{
    [DataContract]
    public class VehicleToEmployeeRelation : ISearchableEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public Employee? Employee { get; set; } = null!;

        public Vehicle? Vehicle { get; set; } = null!;

        public override bool Equals(object obj)
        {
            return obj is VehicleToEmployeeRelation r && r.Id == Id;
        }
    }
}
