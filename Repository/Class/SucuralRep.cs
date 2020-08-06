using DTO.Class;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{
    public class SucuralRep: ISucursalRep
    {
        private readonly StockManagerContext _context;
        public SucuralRep(StockManagerContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Devuelve todas las sucursales
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SucursalDto> GetAllSucursal()
        {
            try
            {
                return this._context.SUCURSAL.ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve la sucursal por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SucursalDto GetSucursalById(int id)
        {
            try
            {
                return this._context.SUCURSAL.Where(x => x.ID == id).FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
