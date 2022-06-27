using Business.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServices
{
    public class DisabledDiscountService : IDisabledDiscountService
    {
        private readonly IDiscountBL _discountBL;      
        public DisabledDiscountService(IDiscountBL discountBL)
        {
            _discountBL = discountBL;
           
        }
        public async Task Run(CancellationToken stoppingToken)
        {           
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {

                    await _discountBL.DisabledDiscount();
                    await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
