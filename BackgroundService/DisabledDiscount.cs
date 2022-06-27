using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServices
{
    public class DisabledDiscount : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Respponse from Background Service - {DateTime.Now}");
                await Task.Delay(1000);
            }
        }
    }
}