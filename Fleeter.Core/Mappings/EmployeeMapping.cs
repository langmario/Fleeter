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
                .GeneratedBy.Native();
            Map(x => x.Firstname)
                .Column("FirstName") // Keep column names consistent, either FirstName or Firstname, not both
                .Length(50)
                .Not.Nullable();
            Map(x => x.Lastname)
                .Column("LastName")
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
            References(x => x.BusinessUnit)
                .Column("BusinessUnitId")
                .Not.Nullable()
                .Cascade.None();

            Version(x => x.Version);
        }
    }
}
