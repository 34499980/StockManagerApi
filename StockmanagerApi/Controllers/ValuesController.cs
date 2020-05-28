using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StockmanagerApi.Models;

namespace StockmanagerApi.Controllers
{
    public class ValuesController : ApiController
    {
        StockManagerDBEntities db = new StockManagerDBEntities();
        // GET api/values
        public IEnumerable<string> Get()
        {
            db.STOCK.ToList();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            var hola = " hola";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
