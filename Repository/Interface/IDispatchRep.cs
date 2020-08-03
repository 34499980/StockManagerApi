using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IDispatchRep
    {
        int saveDispatch(DispatchDto dispatch);
        IEnumerable<Dispatch_StateDto> GetStates();
        IEnumerable<DispatchDto> GetAllDispatches();
        DispatchDto GetDispatchById(int id);
        IEnumerable<StockDto> GetStockIdByDispatch(int id);
    }
}
