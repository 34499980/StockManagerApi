using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthenticationController>
        [HttpPost]
        public bool Post([FromBody] Object value)
        {
            bool result = false;
            try
            {
               UserDto userInput = JsonConvert.DeserializeObject<UserDto>(value.ToString());
               UserDto userOutput = _userBL.GetUserById(userInput.UserName);

                if(userInput.Password == userOutput.Password)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }catch(Exception ex)
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
    }
}
