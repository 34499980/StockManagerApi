using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IDispatchBL
    {
       int saveDispatch(DispatchDto dispatch);
        IEnumerable<Dispatch_StateDto> GetStates();
    }
}
