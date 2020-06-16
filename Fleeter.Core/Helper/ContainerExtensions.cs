using Autofac;
using Fleeter.Core.Database;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Microsoft.Extensions.Hosting;

namespace Fleeter.Core.Helper
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder UseFleeter(this ContainerBuilder cb)
        {
            cb.RegisterType<Startup>().As<IHostedService>();

            // Data
            cb.RegisterType<ConnectionFactory>().As<IConnectionFactory>().SingleInstance().AutoActivate();

            // Services
            cb.RegisterType<UserService>().As<IUserService>();

            // Repositories
            cb.RegisterType<UserRepository>().As<IUserRepository>();

            return cb;
        }
    }
}
