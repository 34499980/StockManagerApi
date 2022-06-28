using Business.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServices
{
    public sealed class ScopeDisabledDIscountService : BackgroundService
    {
      // private readonly IServiceScopeFactory _ServiceScopeFactory;
        private readonly IServiceProvider _serviceProvider;

        public ScopeDisabledDIscountService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IDisabledDiscountService scopedProcessingService =
                    scope.ServiceProvider.GetRequiredService<IDisabledDiscountService>();

                await scopedProcessingService.Run(stoppingToken);
            }

        }
    }
}