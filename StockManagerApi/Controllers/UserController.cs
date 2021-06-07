using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersBL _userBL;
        public UserController(IUsersBL userBL)
        {
            this._userBL = userBL;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        [Authorize]
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
        [HttpPost("GetUserFilter")]
        [Authorize]
        public IEnumerable<UserGetDto> GetUserFilter(UserFilterDto dto)
        {
            try
            {
                var header = Request.Headers["environment"];
                var result = _userBL.GetUserFilter(dto);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost("UpdateUserLenguage")]
        [Authorize]
        public void UpdateUserLenguage(UserLenguageDto dto)
        {
            try
            {               
                _userBL.UpdateUserLenguage(dto);                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [Authorize]
        public UserGetDto Get(string id)
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
        [Authorize]
        public void Post(UserDto value)
        {
            try
            {
                dynamic result = null;
               // var input = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString());
                //UserDto userInput = JsonConvert.DeserializeObject<UserDto>(input["user"].ToString());
                result = this._userBL.GetUserByName(value.UserName);
                if(result != null)
                {
                    this._userBL.UpdateUser(value);
                }
                else
                {
                    this._userBL.SaveUser(value);
                }               

               

            }
            catch (Exception)
            {
                throw new Exception("Error al actualizar o crear usuario!");
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public bool Delete(int id)
        {
            try
            {
                this._userBL.RemoveUser(id);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
