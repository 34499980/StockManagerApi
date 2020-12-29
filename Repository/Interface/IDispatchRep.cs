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
        IEnumerable<Dispatch> GetAllDispatchesByOffice(int idSucursal);
        Dispatch GetDispatchById(int id);
        ICollection<Dispatch_Stock> GetStockIdByDispatch(int id);
        Dispatch GetDispatchByOffice(Dispatch dispatch);
        void UpdateDispatch(Dispatch dispatch);
        ICollection<Stock> GetStockByIdDispatch(int id);
    }
}
