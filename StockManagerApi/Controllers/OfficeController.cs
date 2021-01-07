using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeBL _officeBL;
        public OfficeController(IOfficeBL sucursalBL)
        {
            this._officeBL = sucursalBL;
        }
        // GET: api/<SucursalController>
        [HttpGet]
        public IEnumerable<OfficeDto> Get()
        {
            try
            {
                return this._officeBL.GetAllOffice();
            }
            catch(Exception)
            {
                throw new Exception("Error al recuperar las sucursales!");
            }
           
        }

        // GET api/<SucursalController>/5
        [HttpGet("GetOfficeById/{id}")]
        public OfficeDto GetOfficeById(int id)
        {
            try
            {
                return this._officeBL.GetOfficeById(id);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetOfficeByName")]
        public OfficeDto GetOfficeByName(string name)
        {
            try
            {
                return this._officeBL.GetOfficeByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetOfficesByCountry/{id}")]
        public IEnumerable<OfficeDto> GetOfficesByCountry(int id)
        {
            try
            {
                return this._officeBL.GetOfficesByCountry(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<SucursalController>
        [HttpPost]
        public void Post([FromBody] OfficeDto office)
        {
           
                OfficeDto result = null;                
                result = this._officeBL.GetOfficeByName(office.Name);
                if (result == null)
                {
                    this._officeBL.Add(office);
                }
                else
                {
                    throw new BussinessException("errOfficeAllReadyExist");
                }
                            
                
          
        }

        // PUT api/<SucursalController>/5
        [HttpPut]
        public void Put([FromBody] OfficeDto office)
        {
            try
            {
                OfficeDto result = null;               
                result = this._officeBL.GetOfficeByName(office.Name);
                if (result != null && result.ID == office.ID)
                {
                    this._officeBL.Update(office);
                }
                else
                {
                    throw new BussinessException("errOfficeAllReadyExist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("GetOfficeFilter")]
        public IEnumerable<OfficeGetDto> GetOfficeFilter(OfficeFilterDto dto)
        {
            try
            {
                var header = Request.Headers["environment"];
                var result = _officeBL.GetOfficeFilter(dto);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // DELETE api/<SucursalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                this._officeBL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
