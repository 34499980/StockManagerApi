using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Class
{
    public class SucursalBL: ISucursalBL
    {
        private readonly ISucursalRep _sucursalRep;
        public SucursalBL(ISucursalRep sucursalRep)
        {
            this._sucursalRep = sucursalRep;
        }
        /// <summary>
        /// Devuelve todas las sucursales
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SucursalDto> GetAllSucursal()
        {
            try
            {
                return this._sucursalRep.GetAllSucursal();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
