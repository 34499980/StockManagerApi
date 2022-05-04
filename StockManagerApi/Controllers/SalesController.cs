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
    public class SalesController : ControllerBase
    {
        private readonly ISaleBL _service;
        public SalesController(ISaleBL service)
        {
            this._service = service;
        }
        // GET: api/<SalesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SalesController>/5
        [HttpGet("GetStockBySaleId/{id}")]
        public async Task<SaleDto> GetStockBySaleId(long id)
        {
            return await this._service.GetStockBySaleId(id);
        }

        [HttpGet("ReturnAllSale/{id}")]
        public async Task ReturnAllSale(long id)
        {
            await this._service.ReturnAllSale(id);
        }
        // POST api/<SalesController>
        [HttpPost("Save")]
        [Authorize]
        public async Task Post(SaleDto dto)
        {
            try
            {
                await this._service.save(dto);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("GetSalesByFilters")]
        [Authorize]
        public async Task<ResultDto<SaleDto>> GetSalesByFilters(SaleFilterDto dto)
        {
            try
            {
               return await this._service.GetSalesByFilters(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
