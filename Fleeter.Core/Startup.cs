using Autofac;
using Autofac.Integration.Wcf;
using Fleeter.Core.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Threading.Tasks;

namespace Fleeter.Core
{
    public class Startup : IHostedService
    {
        private readonly List<ServiceHost> _services = new List<ServiceHost>();
        private readonly ILifetimeScope _lifetimeScope;
        private readonly ILogger log;

        public Startup(ILifetimeScope lifetimeScope, ILogger<Startup> logger)
        {
            _lifetimeScope = lifetimeScope;
            log = logger;

            var baseEndpoint = "http://localhost:8080/";

            AddUserService(baseEndpoint);
            AddFleeterService(baseEndpoint);
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _services.ForEach(s =>
            {
                try
                {
                    s.Open();
                    log.LogInformation($"Started service {s.BaseAddresses.First()}");
                }
                catch (Exception ex)
                {
                    log.LogError($"Error while starting service {s.BaseAddresses.First()}");
                }
            });
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _services.ForEach(s => s.Close());
            _lifetimeScope.Dispose();
            return Task.CompletedTask;
        }


        private void AddUserService(string baseEndpoint)
        {
            var endpoint = new Uri(baseEndpoint + "users");

            var host = new ServiceHost(typeof(UserService), endpoint);

            host.AddServiceEndpoint(typeof(IUserService), new WSHttpBinding(), "");
            host.AddDependencyInjectionBehavior<IUserService>(_lifetimeScope);

            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpsGetEnabled = true });

            _services.Add(host);
        }

        private void AddFleeterService(string baseEndpoint)
        {
            var endpoint = new Uri(baseEndpoint + "fleeter");

            var host = new ServiceHost(typeof(FleeterService), endpoint);

            host.AddServiceEndpoint(typeof(IFleeterService), new WSHttpBinding(), "");
            host.AddDependencyInjectionBehavior<IFleeterService>(_lifetimeScope);

            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpsGetEnabled = true });

            _services.Add(host);
        }
    }
}
