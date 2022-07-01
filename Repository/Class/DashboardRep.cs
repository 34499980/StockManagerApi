using Microsoft.EntityFrameworkCore;
using Repository.Class.Context;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Class
{
    public class DashboardRep: IDashboardRep
    {
        private readonly StockManagerContext _context;
        public DashboardRep(StockManagerContext context)
        {
            this._context = context;
        }

        public async Task<List<DashboardData>> GetDataChart(DateTime start, DateTime end, int idOffice)
        {
            try
            {
              return  await this._context.SALE.Where(x =>
                                            x.DateProces.Month >= start.Month &&
                                            x.DateProces.Month < end.Month &&
                                            x.IdOffice == idOffice).GroupBy(z => z.DateProces.Date)
                                            .Select(r => new DashboardData()
                                            {
                                                Label = r.Key.Date.ToShortDateString(), Count = r.Count() }
                                            )
                                            .ToListAsync();
                
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
