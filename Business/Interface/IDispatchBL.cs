using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDispatchBL
    {
        DispatchDto saveDispatch(DispatchDto dispatch);
        IEnumerable<DispatchDto> GetAllDispatchesByOffice();
        DispatchDto GetDispatchById(int id);
        void UpdateDispatch(DispatchDto dispatch);
        Task<ResultDto<DispatchDto>> GetDispatchFilter(DispatchFilterDto dto);
        void FixStock(DispatchDto dto);
    }
}
