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
        IEnumerable<DispatchDto> GetAllDispatchesBySucursal(int idSucursal);
        DispatchDto GetDispatchById(int id);
        ICollection<Dispatch_StockDto> GetStockIdByDispatch(int id);
        DispatchDto GetDispatchBySucursales(DispatchDto dispatch);
        void UpdateDispatch(DispatchDto dispatch);
        ICollection<StockDto> GetStockByIdDispatch(int id);
    }
}
