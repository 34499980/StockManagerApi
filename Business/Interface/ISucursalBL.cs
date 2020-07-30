using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface ISucursalBL
    {
        IEnumerable<SucursalDto> GetAllSucursal();
    }
}
