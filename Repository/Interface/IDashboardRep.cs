using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDashboardRep
    {
        Task<List<DashboardData>> GetDataChart(DateTime start, DateTime end, int idOffice);
    }
}
