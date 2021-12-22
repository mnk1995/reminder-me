using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReminderMe.API.Helper
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var dtTurkishCI = CultureInfo.CreateSpecificCulture("tr-TR");
            var dtNow = DateTime.Now.ToString("dd.MM.yyyy",dtTurkishCI);
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now); 
            //    await Task.Delay(86400000, stoppingToken); // 86,400,000 equals 24 hour
            //}
            //MailHelper.SendMail();
        }
    }
}
