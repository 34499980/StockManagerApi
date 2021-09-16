using AutoMapper;
using Business.Interface;
using ConstantControl;
using DTO.Class;
using Repository.Entities;
using Repository.Interface;
using StockManagerApi.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public class OfficeBL: IOfficeBL
    {
        private readonly IOfficeRep _officeRep;
        private readonly IHistoryRep _historyRep;
        private readonly IMapper _mapper;
        public OfficeBL(IOfficeRep sucursalRep, IMapper mapper, IHistoryRep historyRep)
        {
            this._officeRep = sucursalRep;
            this._historyRep = historyRep;
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
        /// Devuelve las sucursales por un pais
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<OfficeDto> GetOfficesByCountry(int id)
        {
            try
            {
                var result = this._officeRep.GetOfficesByCountry(id);
                return _mapper.Map<IEnumerable<OfficeDto>>(result);
            }
            catch (Exception ex)
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
                    this._historyRep.AddHistory(Constants.HistoryOfficeCreate, office.Name, office.ID, ContextProvider.UserId);
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
                this._historyRep.AddHistory(Constants.HistoryOfficeUpdate, office.Name, office.ID, ContextProvider.UserId);
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
                this._historyRep.AddHistory(Constants.HistoryOfficeDelete, officeModel.Name, officeModel.ID, ContextProvider.UserId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResultDto<OfficeGetDto>> GetOfficeFilter(OfficeFilterDto dto)
        {
            try
            {
                var result = await this._officeRep.GetOfficeFilter(dto);
                return _mapper.Map<ResultDto<OfficeGetDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
    }
}
