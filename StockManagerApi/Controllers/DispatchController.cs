﻿using System;
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
                return this._dispatchBL.GetAllDispatchesByOffice();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }
        [HttpPost("GetDispatchFilter")]
        public IEnumerable<DispatchDto> Get(DispatchFilterDto dto)
        {
            try
            {
                return this._dispatchBL.GetDispatchFilter(dto);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        // GET api/<DispatchController>/5
        [HttpGet("{id}")]
        public IEnumerable<DispatchDto> Get(int id)
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

        // PUT api/<DispatchController>/5
        [HttpPut]
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
        public void Delete(int id)
        {
        }
    }
}
