using Autofac;
using Autofac.Extensions.DependencyInjection;
using Fleeter.Core.Helper;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Fleeter.Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await Host.CreateDefaultBuilder(args)
                    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureContainer<ContainerBuilder>((context, services) =>
                    {
                        services.UseFleeter();
                    })
                    .RunConsoleAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while starting server: {ex.Message}");
            }
        }
    }
}
