using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETapp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASP.NETapp
{
    public class Program
    {
        /// <summary>
        /// initializes the program, acquired personal and business models parameters for the database
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AspNetAppDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception exep)
                {
                    var logger  = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exep, "An Error has occurred during the creation of the database");
                }
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
