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
        public IEnumerable<DispatchDto> Get()
        {
            try
            {
                return this._dispatchBL.GetAllDispatches();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }

        // GET api/<DispatchController>/5
        [HttpGet("{id}")]
        public DispatchDto Get(int id)
        {
            try
            {
              return  this._dispatchBL.GetDispatchById(id);
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        // POST api/<DispatchController>
        [HttpPost]
        public DispatchDto Post(Object value)
        {           
            try
            {
                var input = JsonConvert.DeserializeObject<Dictionary<string,object>>(value.ToString());
                DispatchDto dispatchInput = JsonConvert.DeserializeObject<DispatchDto>(input["dispatch"].ToString());
               return this._dispatchBL.saveDispatch(dispatchInput, input["user"].ToString());

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<DispatchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Object value)
        {
            try
            {
                DispatchDto dispatchInput = JsonConvert.DeserializeObject<DispatchDto>(value.ToString());
                this._dispatchBL.UpdateDispatch(dispatchInput);
                // = JsonConvert.DeserializeObject<DispatchDto>(input["dispatch"].ToString());

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<DispatchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
