using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IDispatchRep
    {
        DispatchDto saveDispatch(DispatchDto dispatch);
        IEnumerable<Dispatch_StateDto> GetStates();
        IEnumerable<DispatchDto> GetAllDispatches();
        DispatchDto GetDispatchById(int id);
        Dictionary<string, object> GetStockIdByDispatch(int id);
        DispatchDto GetDispatchBySucursales(DispatchDto dispatch);
        void UpdateDispatch(DispatchDto dispatch);
    }
}
