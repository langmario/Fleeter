using Autofac;
using Fleeter.Core.Database;
using Fleeter.Core.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Helper
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder UseFleeter(this ContainerBuilder cb)
        {
            cb.RegisterType<Startup>().As<IHostedService>();

            // Data
            cb.RegisterType<ConnectionFactory>().SingleInstance().AutoActivate();

            // Services
            cb.RegisterType<UserService>().As<IUserService>();

            return cb;
        }
    }
}
