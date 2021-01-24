﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceStack.Web;
using StockManagerApi.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockManagerApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsersBL _userBL;
        public AuthenticationController(IUsersBL userBL)
        {
            this._userBL = userBL;
        }
        // GET: api/<AuthenticationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthenticationController>/5
        [HttpGet("{name}")]
        public ImageDto Get(string name)
        {
          
           return this._userBL.GetImageByUser(name);

        }

        // POST api/<AuthenticationController>
        [HttpPost]
        public IActionResult Post(UserDto userInput)
        {

            try
            {
                //  UserDto userInput = JsonConvert.DeserializeObject<UserDto>(value.ToString());
                UserDto userOutput = _userBL.GetUserByName(userInput.UserName);

                if (userOutput != null && userInput.Password == userOutput.Password)
                {
                    return Ok(userOutput);


                }
                else
                {
                    return StatusCode(401, "Usuario o contraseña incorrectos.");

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<AuthenticationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthenticationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("SetAuthorization")]
        public void SetAuthorization(UserDto dto)
        {

            try
            {
                _userBL.SetAuthorization(dto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
