using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration _configuration;
        public AuthenticationController(IUsersBL userBL, IConfiguration configuration)
        {
            this._userBL = userBL;
            this._configuration = configuration;
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
                    var key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);
                    var claims = new[]
                     {
                        new Claim(ClaimTypes.NameIdentifier, userOutput.UserName)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims);
                    

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claimsIdentity,
                        // Nuestro token va a durar un día
                        Expires = DateTime.UtcNow.AddDays(1),
                        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };


                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                    userOutput.token = tokenHandler.WriteToken(createdToken);
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

        [HttpPost("validate")]
        public bool Validate(UserDto dto)
        {

            try
            {
              return  _userBL.Validate(dto);
               
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
