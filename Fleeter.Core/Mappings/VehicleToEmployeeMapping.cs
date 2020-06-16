using Fleeter.Core.Models;
using FluentNHibernate.Mapping;

namespace Fleeter.Core.Mappings
{
    public class VehicleToEmployeeMapping : ClassMap<VehicleToEmployee>
    {
        public VehicleToEmployeeMapping()
        {
            Table("VehicleToEmployeeRelation");
            Id(x => x.Id)
                .GeneratedBy.Native();
            Map(x => x.StartDate)
                .Not.Nullable();
            Map(x => x.EndDate);

            References(x => x.Vehicle)
                .Column("VehicleId")
                .Not.Nullable()
                .Cascade.None();
        }
    }
}
