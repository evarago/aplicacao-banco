namespace AplicacaoBancoExtrato.WebApi {
    using System.IO;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore;
    using Microsoft.Extensions.Configuration;
    using Serilog.Events;
    using Serilog;

    public class Program {
        public static void Main (string[] args) {
            BuildWebHost (args).Run ();
        }

        public static IWebHost BuildWebHost (string[] args) {
            return WebHost.CreateDefaultBuilder (args)
                .UseStartup<Startup> ()
                .ConfigureAppConfiguration ((builderContext, config) => {
                    IHostingEnvironment env = builderContext.HostingEnvironment;
                    config.AddJsonFile ("appsettings.json");
                    config.AddJsonFile ("autofac.json");
                    config.AddJsonFile ($"autofac.{env.EnvironmentName}.json", optional: true);
                    config.AddEnvironmentVariables ();
                })
                .UseSerilog ((hostingContext, loggerConfiguration) => {
                    loggerConfiguration.MinimumLevel.Debug ()
                        .MinimumLevel.Override ("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext ()
                        .WriteTo.RollingFile (Path.Combine (hostingContext.HostingEnvironment.ContentRootPath, "logs/log-{Date}.log"));
                })
                .ConfigureServices (services => services.AddAutofac ())
                .Build ();
        }
    }
}