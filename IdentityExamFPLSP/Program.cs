using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace IdentityExamFPLSP
{
    public class Program
    {
        public static int Main(string[] args)
        {
            string appName = typeof(Startup).Namespace;

            var configuration = GetConfiguration();

            Log.Logger = CreateSerilogLogger(configuration);

            try
            {
                Log.Information("Configuring web host ({DatabaseContext})...", appName);
                var host = BuildWebHost(configuration, args);

                Log.Information("Applying migrations ({DatabaseContext})...", appName);
                host.MigrateDbContext<PersistedGrantDbContext>((_, __) => { })
                    .MigrateDbContext<DatabaseContext>((context, services) =>
                    {
                        var env = services.GetService<IWebHostEnvironment>();
                        var logger = services.GetService<ILogger<ApplicationDbContextSeeding>>();
                        var settings = services.GetService<IOptions<AppSettings>>();

                        new ApplicationDbContextSeeding()
                            .SeedAsync(context, env, logger, settings)
                            .Wait();
                    })
                    .MigrateDbContext<ConfigurationDbContext>((context, services) =>
                    {
                        new ConfigurationDbContextSeed()
                            .SeedAsync(context, configuration)
                            .Wait();
                    });

                Log.Information("Starting web host ({DatabaseContext})...", appName);
                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Program terminated unexpectedly ({DatabaseContext})!", appName);
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

            IHost BuildWebHost(IConfiguration configuration, string[] args) =>
                Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.CaptureStartupErrors(false);
                    webBuilder.ConfigureAppConfiguration(x => x.AddConfiguration(configuration));
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseSerilog();
                })
                .Build();

            Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
            {
                return new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .Enrich.WithProperty("DatabaseContext", appName)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
            }

            IConfiguration GetConfiguration()
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .AddUserSecrets(Assembly.GetAssembly(typeof(Startup)));

                var config = builder.Build();
                return builder.Build();
            }
        }
    }
}
