using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ABSA.PhoneBookAPI.Data;
using ABSA.PhoneBookAPI.Data.Models;

namespace ABSA.PhoneBookAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /// <summary>
        ///     Initializes the database schema.
        /// </summary>
        /// <param name="host">
        ///     An <see cref="IHost" /> program abstraction.
        /// </param>        
        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<PhoneBookContext>();
            DbInitializer.Initialize(context);
        }
    }
}
