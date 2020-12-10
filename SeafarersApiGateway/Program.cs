using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SeafarersApiGateway
{
    public class Program
    {
        /* original API url. When Running please ask for the token
         * 
         * https://pokeapi.co/api/v2/pokemon
           https://cat-fact.herokuapp.com/facts/
         * 
         */

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration(config => config.AddJsonFile($"Ocelot.{environment}.json"));
                }).ConfigureLogging(logging=> logging.AddConsole()) ;
    }
}
