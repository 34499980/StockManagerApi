using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IOfficeBL _sucursalBL;
        public OfficeController(IOfficeBL sucursalBL)
        {
            this._sucursalBL = sucursalBL;
        }
        // GET: api/<SucursalController>
        [HttpGet]
        public IEnumerable<OfficeDto> Get()
        {
            try
            {
                return this._sucursalBL.GetAllOffice();
            }
            catch(Exception)
            {
                throw new Exception("Error al recuperar las sucursales!");
            }
           
        }

        // GET api/<SucursalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SucursalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SucursalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SucursalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
