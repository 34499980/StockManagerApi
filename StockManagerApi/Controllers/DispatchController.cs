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
    public class DispatchController : ControllerBase
    {
        private readonly IDispatchBL _dispatchBL;
        public DispatchController(IDispatchBL dispatch)
        {
            this._dispatchBL = dispatch;
        }
        // GET: api/<DispatchController>
        [HttpGet]
        [Authorize]
        public IEnumerable<DispatchDto> Get()
        {
            try
            {
                return this._dispatchBL.GetAllDispatchesByOffice();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }
        [HttpPost("GetDispatchFilter")]
        [Authorize]
        public async Task<IEnumerable<DispatchDto>> Get(DispatchFilterDto dto)
        {
            try
            {
                return await this._dispatchBL.GetDispatchFilter(dto);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        // GET api/<DispatchController>/5
        [HttpGet("{id}")]
        [Authorize]
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
        [Authorize]
        public DispatchDto Post(DispatchDto dto)
        {           
            try
            {    
              return this._dispatchBL.saveDispatch(dto);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("FixStock")]
        [Authorize]
        public void FixStock (DispatchDto dto)
        {
            try
            {
                 this._dispatchBL.FixStock(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<DispatchController>/5
        [HttpPut]
        [Authorize]
        public void Put(DispatchDto dto)
        {
            try
            {
             
                this._dispatchBL.UpdateDispatch(dto);                

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<DispatchController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}
