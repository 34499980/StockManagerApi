using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        public IEnumerable<StockDto> Get(string id)
        {
            try
            {
                dynamic result = null;
                string query = "";
                if (id.Contains("where"))
                {
                    var input = id.Split(';');
                    query = input[0].Replace("idsucursal", "SS.idsucursal").Replace(":","=");
                   
                    for (int i = 1; i<input.Length; i++)
                    {
                        query += " and " + input[i].Replace(":", " like '%");
                        query += "%'";
                    }
                    result =  this._stockBL.GetStockByParams(query);
                }
                else
                {
                   // var input = JsonConvert.DeserializeObject<StockDto>(id);
                    result = this._stockBL.GetStockByCode(id);
                }
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetStockById/{id}")]
        public StockDto GetStockById(int id)
        {


            var result = this._stockBL.GetStockById(id);
              
            return result;
           
        }
        [HttpPost("GetStockFilter")]
        public IEnumerable<Stock_OfficeDto> GetStockFilter([FromBody] StockFilterDto dto)
        {
            try
            {
                var header = Request.Headers["environment"];
                var result = _stockBL.GetStockFilter(dto);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // POST api/<StockController>
        [HttpPost]
        public void Post(StockPostDto dto)
        {
            try
            {
                this._stockBL.SaveStock(dto,1);
               
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<StockController>/5
        [HttpPut]
        public void Put(StockPostDto dto)
        {
            this._stockBL.UpdateStock(dto);
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._stockBL.delete(id);
        }
    }
}
