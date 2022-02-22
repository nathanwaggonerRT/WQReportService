using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WQReportService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WQReportService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        
             Host.CreateDefaultBuilder(args)
                //.UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    var connection = hostContext.Configuration.GetConnectionString("wqconnection");
                    var optionsBuilder = new DbContextOptionsBuilder<Context>();
                    optionsBuilder.UseSqlServer(connection);//,
                    services.AddScoped<Context>(s => new Context(optionsBuilder.Options));
                    services.AddHostedService<Worker>();

                });
            
        
    }
}
