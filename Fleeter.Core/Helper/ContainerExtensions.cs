using Autofac;
using Fleeter.Core.Database;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Microsoft.Extensions.Hosting;

namespace Fleeter.Core.Helper
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder UseFleeter(this ContainerBuilder b)
        {
            b.RegisterType<Startup>().As<IHostedService>();
            b.RegisterType<ConnectionFactory>().As<IConnectionFactory>().SingleInstance().AutoActivate();


            // Services
            b.RegisterType<UserService>().As<IUserService>();
            b.RegisterType<FleeterService>().As<IFleeterService>();

            // Repositories
            b.RegisterType<UserRepository>().As<IUserRepository>();
            b.RegisterType<BusinessUnitRepository>().As<IBusinessUnitRepository>();
            b.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            b.RegisterType<VehicleRepository>().As<IVehicleRepository>();

            return b;
        }
    }
}
