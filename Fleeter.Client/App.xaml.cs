using Autofac;
using Fleeter.Client.Controller;
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

            builder.RegisterType<RootShellController>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();

            var container = builder.Build();

            var controller = container.Resolve<RootShellController>();
            controller.Initialize();
        }
    }
}
