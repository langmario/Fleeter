using Autofac;
using Fleeter.Client.Controller;
using Fleeter.Client.Controllers;
using Fleeter.Client.Services;
using Fleeter.Client.Views;
using System.Windows;

namespace Fleeter.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
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

            // Services
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<UsersService>().As<IUsersService>();
            builder.RegisterType<BusinessUnitService>().As<IBusinessUnitService>();

            var container = builder.Build();
            var rootController = container.Resolve<RootShellController>();
            rootController.Initialize();
        }
    }
}
