﻿using System;
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
        private readonly IOfficeBL _officeBL;
        public OfficeController(IOfficeBL sucursalBL)
        {
            this._officeBL = sucursalBL;
        }
        // GET: api/<SucursalController>
        [HttpGet]
        public IEnumerable<OfficeDto> Get()
        {
            try
            {
                return this._officeBL.GetAllOffice();
            }
            catch(Exception)
            {
                throw new Exception("Error al recuperar las sucursales!");
            }
           
        }

        // GET api/<SucursalController>/5
        [HttpGet("GetOfficeById/{id}")]
        public OfficeDto GetOfficeById(int id)
        {
            try
            {
                return this._officeBL.GetOfficeById(id);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetOfficeByName")]
        public OfficeDto GetOfficeByName(string name)
        {
            try
            {
                return this._officeBL.GetOfficeByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<SucursalController>
        [HttpPost]
        public void Post([FromBody] OfficeDto office)
        {
            try
            {
                dynamic result = null;
                // var input = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString());
                //UserDto userInput = JsonConvert.DeserializeObject<UserDto>(input["user"].ToString());
                result = this._officeBL.GetOfficeByName(office.Name);
                if (result != null)
                {
                    this._officeBL.Update(office);
                }
                else
                {
                    this._officeBL.Add(office);
                }
                
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<SucursalController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] OfficeDto office)
        {
            try
            {
                this._officeBL.Update(office);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("GetUOfficeFilter")]
        public IEnumerable<OfficeGetDto> GetOfficeFilter(OfficeFilterDto dto)
        {
            try
            {
                var header = Request.Headers["environment"];
                var result = _officeBL.GetOfficeFilter(dto);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // DELETE api/<SucursalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                this._officeBL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}