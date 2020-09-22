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
    public class StatesController : ControllerBase
    {
        private readonly IUsersBL _userBL;
        private readonly IStockBL _stockBL;
        private readonly IDispatchBL _dispatchBL;
        public StatesController(IUsersBL userBL,IStockBL stockBL, IDispatchBL dispatchBL)
        {
            this._userBL = userBL;
            this._stockBL = stockBL;
            this._dispatchBL = dispatchBL;
        }
        // GET: api/<StatesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StatesController>/5
        [HttpGet("{id}")]
        public IEnumerable<StateBaseDto> Get(string id)
        {
            try
            {
                dynamic result= null;
                switch (id)
                {
                    case "dispatch":
                      result =  this._dispatchBL.GetStates();
                        break;
                    case "stock":
                      result =  this._stockBL.GetStates();
                        break;
                    case "rules":
                        result = this._userBL.GetAllRules();
                        break;
                }
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
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
    }
}
