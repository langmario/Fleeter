using Fleeter.Core.Mappings;
using Fleeter.Core.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Database
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly ISessionFactory _factory;

        public ConnectionFactory()
        {
            _factory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(@"FleetManagement.db"))
                .Mappings(m => m.FluentMappings.Add<UserMapping>()
                    .Conventions.Add(DefaultLazy.Never()))
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return _factory.OpenSession();
        }
    }
}
