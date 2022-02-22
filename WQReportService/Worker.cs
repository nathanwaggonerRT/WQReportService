using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WQReportService.Data;


namespace WQReportService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<Context>();
            var dataAccess = new DataAccess(context);
            while (!stoppingToken.IsCancellationRequested)
            {
                
               

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var scheduledReportCheck = dataAccess.Get();
                _logger.LogInformation("Result: {reportname}", scheduledReportCheck.reportname);
                var reportList = dataAccess.GetList();
                foreach(var report in reportList)
                {
                    _logger.LogInformation("Report: {recipient}, {reportname}", report.recipient, report.reportname);
                }
                
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
