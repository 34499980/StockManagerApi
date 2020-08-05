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
    public class StockController : ControllerBase
    {
        private readonly IStockBL _stockBL;
        public StockController(IStockBL stockBL)
        {
            this._stockBL = stockBL;
        }
        // GET: api/<StockController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public StockDto Get(int id)
        {
            try
            {
                return this._stockBL.GetStockById(id);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<StockController>
        [HttpPost]
        public void Post(Object value)
        {
            try
            {
                var input = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString());
                StockDto stockInput = JsonConvert.DeserializeObject<StockDto>(input["stock"].ToString());
                this._stockBL.SaveStock(stockInput, input["user"].ToString());
               
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<StockController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
