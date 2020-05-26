using StockmanagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StockmanagerApi.Controllers
{
    public class StockController : ApiController
    {
        StockManagerDBEntities db = new StockManagerDBEntities();
        // GET: api/Stock
        public IEnumerable<STOCK> Get()
        {
            return db.STOCK.ToList<STOCK>();
        }

        // GET: api/Stock/5
        public STOCK Get(string Code)
        {
            return (STOCK)db.STOCK.Where(x => x.Code == Code);
        }

        // POST: api/Stock
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stock/5
        public void Put(STOCK stock)
        {
            db.STOCK.Add(stock);
            db.SaveChanges();
        }

        // DELETE: api/Stock/5
        public void Delete(int id)
        {
        }
    }
}
