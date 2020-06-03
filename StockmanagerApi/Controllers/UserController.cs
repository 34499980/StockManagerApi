using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockmanagerApi.Models;

namespace StockmanagerApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        StockManagerDBEntities db = new StockManagerDBEntities();
        // GET api/values
        public IEnumerable<string> Get()
        {
            db.USUARIO.ToList();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public USUARIO Get(string id)
        {

            var input = JsonConvert.DeserializeObject<USUARIO>(id);

            dynamic result = "";            
            try
            {
                //result = (USUARIO)db.USUARIO.Where(x => x.UserName == input.UserName).FirstOrDefault();
                ////if (result.password == usuario.Password)
                ////{
                ////    return result;
                ////}
                throw new Exception("Usuario o contraseña incorrecta!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/values
        public USUARIO Post([Microsoft.AspNetCore.Mvc.FromBody] USUARIO value)
        {
            //var input = JsonConvert.DeserializeObject<USUARIO>(value);

            dynamic result = "";
            try
            {
                result = (USUARIO)db.USUARIO.Where(x => x.UserName == value.UserName).FirstOrDefault();
                if(result != null)
                {
                    if (result.password == value.Password)
                    {
                        return result;
                    }
                    throw new Exception("Usuario o contraseña incorrecta");
                }
                else
                {
                    throw new Exception("No se encuentra el usuario.");
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/values/5
        public void Put(int id, [Microsoft.AspNetCore.Mvc.FromBody] USUARIO usuario)
        {
         
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
