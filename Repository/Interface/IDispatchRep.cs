using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IDispatchRep
    {
        Dispatch saveDispatch(Dispatch dispatch);
        IEnumerable<Dispatch_State> GetStates();
        IEnumerable<Dispatch> GetAllDispatchesBySucursal(int idSucursal);
        Dispatch GetDispatchById(int id);
        ICollection<Dispatch_Stock> GetStockIdByDispatch(int id);
        Dispatch GetDispatchBySucursales(Dispatch dispatch);
        void UpdateDispatch(Dispatch dispatch);
        ICollection<Stock> GetStockByIdDispatch(int id);
    }
}
