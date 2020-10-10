using DTO.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ISucursalRep
    {
        IEnumerable<Sucursal> GetAllSucursal();
        Sucursal GetSucursalById(int id);
    }
}
