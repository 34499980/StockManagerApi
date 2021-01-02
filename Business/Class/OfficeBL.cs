using AutoMapper;
using Business.Interface;
using DTO.Class;
using Repository.Entities;
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
        /// <summary>
        /// Devuelve la sucursal por nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public OfficeDto GetOfficeByName(string name)
        {
            try
            {
              var result =  this._officeRep.GetOfficeByName(name);
                return _mapper.Map<OfficeDto>(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve sucursal por id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public OfficeDto GetOfficeById(int id)
        {
            try
            {
                var result = this._officeRep.GetOfficeById(id);
                return _mapper.Map<OfficeDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add(OfficeDto office)
        {
            try
            {               
                var officeModel = this._officeRep.GetOfficeByName(office.Name);
                if(officeModel == null)
                {
                    var officeInput = _mapper.Map<Office>(office);
                     this._officeRep.Add(officeInput);                   
                }               

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Update(OfficeDto office)
        {
            try
            {
                var officeModel = _officeRep.GetOfficeById(office.ID);
                _mapper.Map<OfficeDto, Office>(office, officeModel);
                this._officeRep.Update(officeModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int id)
        {

            try
            {
                var officeModel = _officeRep.GetOfficeById(id);
                officeModel.Active = false;
                _officeRep.Delete(officeModel);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<OfficeGetDto> GetOfficeFilter(OfficeFilterDto dto)
        {
            try
            {
                var result = this._officeRep.GetOfficeFilter(dto);
                return _mapper.Map<IEnumerable<OfficeGetDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
    }
}
