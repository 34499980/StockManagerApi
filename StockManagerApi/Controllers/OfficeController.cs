using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
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
        [HttpGet("GetOfficeChipByName/{name}")]
        [Authorize]
        public async Task<IEnumerable<ItemDto>> GetOfficeChipByName(string name)
        {
            try
            {
                return await this._officeBL.GetOfficeChipByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetOfficesByCountry/{id}")]
        [Authorize]
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
        [HttpGet("GetOfficesChipByCountry")]
        [Authorize]
        public IEnumerable<ItemDto> GetOfficesChipByCountry()
        {
            try
            {
                return this._officeBL.GetOfficesChipByCountry();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<SucursalController>
        [HttpPost]
        [Authorize]
        public Task Post([FromBody] OfficeDto office)
        {
          return  this._officeBL.Add(office);
        }

        // PUT api/<SucursalController>/5
        [HttpPut]
        [Authorize]
        public Task Put([FromBody] OfficeDto dto)
        {
            try
            {
               return  _officeBL.Update(dto);             
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("GetOfficeFilter")]
        [Authorize]
        public async Task<ResultDto<OfficeGetDto>> GetOfficeFilter(OfficeFilterDto dto)
        {
            try
            {
                var header = Request.Headers["environment"];
                var result = await _officeBL.GetOfficeFilter(dto);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // DELETE api/<SucursalController>/5
        [HttpDelete("{id}")]
        [Authorize]
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
