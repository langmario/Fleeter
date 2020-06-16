using Fleeter.Core.Models;
using FluentNHibernate.Mapping;

namespace Fleeter.Core.Mappings
{
    public class BusinessUnitMapping : ClassMap<BusinessUnit>
    {
        public BusinessUnitMapping()
        {
            Table("BusinessUnits");
            Id(x => x.Id)
                .Not.Nullable()
                .GeneratedBy.Native();
            Map(x => x.Name)
                .Length(100)
                .Not.Nullable();
            Map(x => x.Description)
                .Length(250);
            Version(x => x.Version);
        }
    }
}
