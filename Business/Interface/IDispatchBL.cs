using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IDispatchBL
    {
        DispatchDto saveDispatch(DispatchDto dispatch);
        IEnumerable<DispatchDto> GetAllDispatchesByOffice();
        IEnumerable<DispatchDto>GetDispatchById(int id);
        void UpdateDispatch(DispatchDto dispatch);
        IEnumerable<DispatchDto> GetDispatchFilter(DispatchFilterDto dto);
    }
}
