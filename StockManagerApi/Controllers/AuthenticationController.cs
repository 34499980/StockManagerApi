using System;
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
        public async Task<IActionResult> Post(UserDto userInput)
        {            
            bool ok = false;            
            try
            {
             //  UserDto userInput = JsonConvert.DeserializeObject<UserDto>(value.ToString());
               UserDto userOutput = _userBL.GetUserByName(userInput.UserName);

                if(userOutput != null && userInput.Password == userOutput.Password)
                {
                    return Ok(true);
                 
                   
                }
                else
                {
                    return StatusCode(401, "Usuario o contraseña incorrectos.");

                }
               
                return Ok(ok);
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
