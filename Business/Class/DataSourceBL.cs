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
    public class DataSourceBL: IDataSourceBL
    {
        private readonly IDataSourceRep _dataSourceRep;
        private readonly IMapper _mapper;
        public DataSourceBL(IDataSourceRep dataSourceRep, IMapper mapper)
        {
            this._dataSourceRep = dataSourceRep;
            this._mapper = mapper;
        }
        public IEnumerable<CountryDto> GetAllCountries()
        {
            try
            {
                var result = this._dataSourceRep.GetAllCountries();
                return _mapper.Map<IEnumerable<CountryDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Dispatch_StateDto> GetAllDispatchState()
        {
            try
            {
                var result = this._dataSourceRep.GetAllDispatchState();
                return _mapper.Map<IEnumerable<Dispatch_StateDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Stock_StateDto> GetAllStockState()
        {
            try
            {
                var result = this._dataSourceRep.GetAllStockState();
                return _mapper.Map<IEnumerable<Stock_StateDto>>(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<RolesDto> GetAllRoles()
        {
            try
            {
                var result = this._dataSourceRep.GetAllRoles();
                return _mapper.Map<IEnumerable<RolesDto>>(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<ActionsDto> GetActions()
        {
            try
            {
                var result = this._dataSourceRep.GetActions();
                return _mapper.Map<IEnumerable<ActionsDto>>(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
