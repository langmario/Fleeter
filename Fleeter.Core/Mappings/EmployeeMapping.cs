using Fleeter.Core.Models;
using FluentNHibernate.Mapping;

namespace Fleeter.Core.Mappings
{
    public class EmployeeMapping : ClassMap<Employee>
    {
        public EmployeeMapping()
        {
            Table("Employees");
            Id(x => x.Id)
                .Not.Nullable()
                .GeneratedBy.Native();
            Map(x => x.FirstName)
                .Length(50)
                .Not.Nullable();
            Map(x => x.LastName)
                .Length(50)
                .Not.Nullable();
            Map(x => x.EmployeeNumber)
                .Not.Nullable();
            Map(x => x.Salutation)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Title)
                .Length(50)
                .Not.Nullable();

            Version(x => x.Version)
                .Not.Nullable();
        }
    }
}
