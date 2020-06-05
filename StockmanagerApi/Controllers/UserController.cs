using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockmanagerApi.Class;
using StockmanagerApi.Models;

namespace StockmanagerApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        StockManagerDBEntities db = new StockManagerDBEntities();
        // GET api/values
        public IEnumerable<UsuarioDTO> Get()
        {
            List<UsuarioDTO> result = new List<UsuarioDTO>();
            UsuarioDTO user = null;
           // var result = (IEnumerable<UsuarioDTO>)db.USUARIO.ToList<USUARIO>();
            foreach (var item in db.USUARIO.ToList<USUARIO>())
            {
                user = new UsuarioDTO();
                user.ID = item.ID;
                user.UserName = item.UserName;
                user.LASTNAME = item.LASTNAME;
                user.Name = item.Name;
                user.Password = item.Password;
                user.PostalCode = item.PostalCode;             
                user.IdSucursal = item.IdSucursal;
                result.Add(user);
            }

            return result;
        }

        // GET api/values/5
        public USUARIO Get([FromUri] string id)
        {
            foreach(var item in id)
            {
                var asd = "";
            }

          //  var input = JsonConvert.DeserializeObject<USUARIO>(id);

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
        public dynamic Post([Microsoft.AspNetCore.Mvc.FromBody] USUARIO value)
        {
            //var input = JsonConvert.DeserializeObject<USUARIO>(value);

            dynamic result = "";
            try
            {
                result = (USUARIO)db.USUARIO.Where(x => x.UserName == value.UserName).FirstOrDefault();
                if(result != null)
                {
                    if (result.Password == value.Password)
                    {
                        UsuarioDTO user = new UsuarioDTO();
                        user = new UsuarioDTO();
                        user.ID = result.ID;
                        user.UserName = result.UserName;
                        user.LASTNAME = result.LASTNAME;
                        user.Name = result.Name;
                        user.Password = result.Password;
                        user.PostalCode = result.PostalCode;
                        user.IdSucursal = result.IdSucursal;

                        return user;
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
