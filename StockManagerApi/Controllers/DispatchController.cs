using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        private readonly IDispatchBL _dispatchBL;
        public DispatchController(IDispatchBL dispatch)
        {
            this._dispatchBL = dispatch;
        }
        // GET: api/<DispatchController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DispatchController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DispatchController>
        [HttpPost]
        public int Post([FromBody] Object value)
        {           
            try
            {
                DispatchDto dispatchInput = JsonConvert.DeserializeObject<DispatchDto>(value.ToString());
               return this._dispatchBL.saveDispatch(dispatchInput);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<DispatchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DispatchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
