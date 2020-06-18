using Fleeter.Core.Models;
using FluentNHibernate.Mapping;

namespace Fleeter.Core.Mappings
{
    public class VehicleMapping : ClassMap<Vehicle>
    {
        public VehicleMapping()
        {
            Table("Vehicles");
            Id(x => x.Id)
                .GeneratedBy.Native();

            Map(x => x.LicensePlate)
                .Length(50)
                .Not.Nullable();

            Map(x => x.Brand)
                .Length(50)
                .Not.Nullable();

            Map(x => x.Model)
                .Length(50)
                .Not.Nullable();

            Map(x => x.Insurance)
                .Not.Nullable();

            Map(x => x.LeasingFrom)
                .Not.Nullable();

            Map(x => x.LeasingTo)
                .Not.Nullable();

            Map(x => x.LeasingRate)
                .Not.Nullable();

            HasMany(x => x.EmployeeRelations)
                .KeyColumn("VehicleId")
                .Cascade.All();

            Version(x => x.Version);
        }
    }
}
