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
        IEnumerable<DispatchDto> GetAllDispatches();
        DispatchDto GetDispatchById(int id);
    }
}
