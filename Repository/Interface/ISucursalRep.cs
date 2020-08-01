using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ISucursalRep
    {
        IEnumerable<SucursalDto> GetAllSucursal();
        SucursalDto GetSucursalById(int id);
    }
}
