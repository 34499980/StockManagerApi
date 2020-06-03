using StockmanagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StockmanagerApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StockController : ApiController
    {
        StockManagerDBEntities db = new StockManagerDBEntities();
        // GET: api/Stock
        public IEnumerable<STOCK> Get()
        {            
            try
            {
                return db.STOCK.ToList<STOCK>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        // GET: api/Stock/5
        public STOCK Get(string id)
        {
            try
            {
                return db.STOCK.Where(x => x.Code == id).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        // POST: api/Stock
        [HttpPost]        
        public void Post([FromBody] STOCK stock)
        {
            try
            {
                db.STOCK.Add(stock);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/Stock/5
        public void Put(STOCK stock)
        {
            try
            {
                db.STOCK.Add(stock);
                db.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        // DELETE: api/Stock/5
        public void Delete(int id)
        {
            try
            {
                 STOCK result = db.STOCK.Where(x => x.Code == id.ToString()).FirstOrDefault();
                 result.IdState = 2;
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
