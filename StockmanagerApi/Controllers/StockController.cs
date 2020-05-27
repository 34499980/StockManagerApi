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
        public STOCK Get(int id)
        {
            try
            {
                return db.STOCK.Where(x => x.Code == id.ToString()).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        // POST: api/Stock
        public void Post([FromBody]string value)
        {
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
