using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IHistoryBL
    {
        Task<ResultDto<HistoryDto>> GetHistoryFilter(HistoryFilterDto dto);
    }
}
