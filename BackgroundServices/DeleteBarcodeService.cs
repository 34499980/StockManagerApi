using Business.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServices
{
    public class DeleteBarcodeService: IDeleteBarcodeService
    {
        private readonly IStockBL _stockBL;
        public DeleteBarcodeService(IStockBL stockBL)
        {
            _stockBL = stockBL;

        }
        public async Task Run(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {

                    await _stockBL.DeleteBarcodeFiles();
                    await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
