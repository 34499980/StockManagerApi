using AutoMapper;
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
        private readonly IMapper _mapper;
        public SucursalBL(ISucursalRep sucursalRep, IMapper mapper)
        {
            this._sucursalRep = sucursalRep;
            this._mapper = mapper;
        }
        /// <summary>
        /// Devuelve todas las sucursales
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SucursalDto> GetAllSucursal()
        {
            try
            {
                var result = this._sucursalRep.GetAllSucursal();
                return _mapper.Map<IEnumerable<SucursalDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
