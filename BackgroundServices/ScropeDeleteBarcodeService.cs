using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServices
{
    public class ScropeDeleteBarcodeService : BackgroundService
    {
        // private readonly IServiceScopeFactory _ServiceScopeFactory;
        private readonly IServiceProvider _serviceProvider;

        public ScropeDeleteBarcodeService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IDeleteBarcodeService scopedProcessingService =
                    scope.ServiceProvider.GetRequiredService<IDeleteBarcodeService>();

                await scopedProcessingService.Run(stoppingToken);
            }

        }
    }
 
}
