using Fleeter.Core.Models;
using FluentNHibernate.Mapping;

namespace Fleeter.Core.Mappings
{
    public class VehicleToEmployeeRelationMapping : ClassMap<VehicleToEmployeeRelation>
    {
        public VehicleToEmployeeRelationMapping()
        {
            Table("VehicleToEmployeeRelation");

            Id(x => x.Id)
                .GeneratedBy.Native();

            Map(x => x.StartDate)
                .Not.Nullable();

            Map(x => x.EndDate);

            References(x => x.Employee)
                .Column("EmployeeId")
                .Not.Nullable()
                .Cascade.None();

            References(x => x.Vehicle)
                .Column("VehicleId")
                .Not.Nullable()
                .LazyLoad()
                .Cascade.None();
        }
    }
}
