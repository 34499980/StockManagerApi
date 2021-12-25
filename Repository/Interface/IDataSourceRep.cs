using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IDataSourceRep
    {
        IEnumerable<Country> GetAllCountries();
        IEnumerable<Dispatch_State> GetAllDispatchState();
        IEnumerable<Stock_State> GetAllStockState();
        IEnumerable<Roles> GetAllRoles();
        IEnumerable<Actions> GetActions();
    }
}
