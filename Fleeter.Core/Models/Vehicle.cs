using Fleeter.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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

        [DataMember]
        public IList<VehicleToEmployeeRelation>? EmployeeRelations { get; set; } = new List<VehicleToEmployeeRelation>();

        public virtual void AddRelation(VehicleToEmployeeRelation r)
        {
            EmployeeRelations!.Add(new VehicleToEmployeeRelation
            {
                Employee = r.Employee,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                Vehicle = this
            });
        }

        public virtual bool RemoveRelation(VehicleToEmployeeRelation r)
        {
            return EmployeeRelations!.Remove(r);
        }

        [DataMember]
        public int Version { get; set; }
    }
}
