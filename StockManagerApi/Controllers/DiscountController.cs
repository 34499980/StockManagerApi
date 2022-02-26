using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountBL _discountBL;
        public DiscountController(IDiscountBL discountBL)
        {
            this._discountBL = discountBL;
        }
        // GET: api/<DiscountController>
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<DiscountDto>> Get()
        {
            try
            {
                return await this._discountBL.GetAllDiscountByOffice();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }
        [HttpPost("GetDiscountFilter")]
        [Authorize]
        public async Task<ResultDto<DiscountDto>> Get(DiscountFilterDto dto)
        {
            try
            {
                return await this._discountBL.GetDiscountFilter(dto);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        // GET api/<DiscountController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<DiscountDto> Get(int id)
        {
            try
            {                   
                return  await this._discountBL.GetDiscountById(id);
               
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        // POST api/<DiscountController>
        [HttpPost]
        [Authorize]
        public async Task<DiscountDto> Post(DiscountPostDto dto)
        {           
            try
            {    
              return await this._discountBL.saveDiscount(dto);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }      

        // PUT api/<DiscountController>/5
        [HttpPut]
        [Authorize]
        public async Task Put(DiscountDto dto)
        {
            try
            {
             
                await this._discountBL.UpdateDiscount(dto);                

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<DiscountController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task Delete(int id)
        {
            try
            {

                await this._discountBL.removeDiscount(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
