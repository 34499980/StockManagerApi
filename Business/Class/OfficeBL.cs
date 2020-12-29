using AutoMapper;
using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Class
{
    public class OfficeBL: IOfficeBL
    {
        private readonly IOfficeRep _officeRep;
        private readonly IMapper _mapper;
        public OfficeBL(IOfficeRep sucursalRep, IMapper mapper)
        {
            this._officeRep = sucursalRep;
            this._mapper = mapper;
        }
        /// <summary>
        /// Devuelve todas las sucursales
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OfficeDto> GetAllOffice()
        {
            try
            {
                var result = this._officeRep.GetAllOffice();
                return _mapper.Map<IEnumerable<OfficeDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
