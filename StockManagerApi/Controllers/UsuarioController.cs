﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsersBL _userBL;
        public UsuarioController(IUsersBL userBL)
        {
            this._userBL = userBL;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
  
        public IEnumerable<UserDto> Get()
        {
            try
            {
                var header = Request.Headers["environment"];
                var result = _userBL.GetAllUsers();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public UserDto Get(string id)
        {
            try
            {
              var result = _userBL.GetUserByName(id);
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
           
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post(Object value)
        {
            try
            {
                dynamic result = null;
                var input = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString());
                UserDto userInput = JsonConvert.DeserializeObject<UserDto>(input["user"].ToString());
                result = this._userBL.GetUserByName(userInput.UserName);
                if(result != null)
                {
                    this._userBL.UpdateUser(userInput);
                }
                else
                {
                    this._userBL.SaveUser(userInput);
                }               

               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
