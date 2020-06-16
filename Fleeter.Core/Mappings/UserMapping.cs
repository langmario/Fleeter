using Fleeter.Core.Models;
using FluentNHibernate.Mapping;

namespace Fleeter.Core.Mappings
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {

            Table("Users");
            Id(u => u.Id)
                .GeneratedBy.Native();
            Map(u => u.Username)
                .Not.Nullable().Length(20);
            Map(u => u.Firstname).Length(50);
            Map(u => u.Lastname)
                .Not.Nullable().Length(50);
            Map(u => u.PasswordHash)
                .Column("Password")
                .Not.Nullable().Length(60);
            Map(u => u.IsAdmin)
                .Not.Nullable();
            Version(u => u.Version);
        }
    }
}
