using Autofac;
using Fleeter.Client.Controller;
using Fleeter.Client.Controllers;
using Fleeter.Client.Services;
using System.Windows;

namespace Fleeter.Client
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            // Controller
            builder.RegisterType<RootShellController>().SingleInstance();
            builder.RegisterType<AppShellController>().SingleInstance();
            builder.RegisterType<HomeController>().SingleInstance();
            builder.RegisterType<AdminUsersController>().SingleInstance();
            builder.RegisterType<AppBusinessUnitController>().SingleInstance();
            builder.RegisterType<AppCostsPerMonthController>().SingleInstance();
            builder.RegisterType<AppEmployeeController>().SingleInstance();

            // Services
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<UsersService>().As<IUsersService>();
            builder.RegisterType<BusinessUnitService>().As<IBusinessUnitService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();

            var container = builder.Build();
            var rootController = container.Resolve<RootShellController>();
            rootController.Initialize();
        }
    }
}
