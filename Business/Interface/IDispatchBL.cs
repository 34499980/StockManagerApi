using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IDispatchBL
    {
        DispatchDto saveDispatch(DispatchDto dispatch,string user);
        IEnumerable<Dispatch_StateDto> GetStates();
        IEnumerable<DispatchDto> GetAllDispatchesByOffice(string user);
        IEnumerable<DispatchDto>GetDispatchById(int id);
        void UpdateDispatch(DispatchDto dispatch, string user);
    }
}
