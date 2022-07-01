using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDashboardBL
    {
        Task<DashboardDto> GetDataChart(DashboardFilterDto dto);
    }
}
