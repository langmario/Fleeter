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
            builder.RegisterType<RootShellController>();
            builder.RegisterType<AppShellController>();
            builder.RegisterType<HomeController>();
            builder.RegisterType<AdminUsersController>();
            builder.RegisterType<AppBusinessUnitController>();
            builder.RegisterType<AppCostsPerMonthController>();
            builder.RegisterType<AppEmployeeController>();
            builder.RegisterType<AppVehicleController>();
            builder.RegisterType<ChangePasswordDialogController>();
            builder.RegisterType<AddEmployeeRelationController>();

            // Services
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<UsersService>().As<IUsersService>();
            builder.RegisterType<BusinessUnitService>().As<IBusinessUnitService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<VehicleService>().As<IVehicleService>();
            builder.RegisterType<CalculationService>().As<ICalculationService>();

            var container = builder.Build();
            var rootController = container.Resolve<RootShellController>();
            rootController.Initialize();
        }
    }
}
