using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServices
{
    public interface IDeleteBarcodeService
    {
        Task Run(CancellationToken stoppingToken);
    }
}
