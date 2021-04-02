using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSourceController : ControllerBase
    {
        private readonly IDataSourceBL _dataSourceBL;
  
        public DataSourceController(IDataSourceBL dataSourceBL)
        {
            this._dataSourceBL = dataSourceBL;            
        }
        // GET: api/<StatesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
            

        // POST api/<StatesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("GetAllCountries")]
        [Authorize]
        public IEnumerable<CountryDto> GetAllCountries()
        {
            try
            {
                return this._dataSourceBL.GetAllCountries();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetDispatchState")]
        [Authorize]
        public IEnumerable<Dispatch_StateDto> GetDispatchState()
        {
            try
            {
                return this._dataSourceBL.GetAllDispatchState();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetStockState")]
        [Authorize]
        public IEnumerable<Stock_StateDto> GetStockchState()
        {
            try
            {
                return this._dataSourceBL.GetAllStockState();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAllRoles")]
        [Authorize]
        public IEnumerable<RolesDto> GetAllRoles()
        {
            try
            {
                return this._dataSourceBL.GetAllRoles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
