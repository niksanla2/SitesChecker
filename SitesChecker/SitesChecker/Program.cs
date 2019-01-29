using Autofac;
using SitesChecker.Configs;
using SitesChecker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitesChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();
            var app = container.Resolve<IApplication>();
            app.RunAsync().GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<SiteStatusChecker>().As<ISiteStatusChecker>();

            var configuration = new Configuration()
            {
                Sites = new List<SiteConfig>
                {
                    new SiteConfig
                    {
                        Url = new Uri ("https://httpstat.us/200"),
                        CheckInterval = TimeSpan.FromSeconds(1)
                    },
                    new SiteConfig
                    {
                        Url = new Uri ("https://httpstat.us/500"),
                        CheckInterval = TimeSpan.FromSeconds(2)
                    },
                }
            };
            builder.RegisterInstance(configuration);

            var displayService = new DisplayService();
            builder.RegisterInstance(displayService);

            return builder.Build();
        }
    }
}
