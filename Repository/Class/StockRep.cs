using DTO.Class;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Class
{
    public class StockRep : IStockRep
    {
        private readonly StockManagerContext _context;
        public StockRep(StockManagerContext context)
        {
            this._context = context;
        }
        public StockDto GetStockById(long id)
        {
            try
            {
                return this._context.STOCK.Where(x => x.ID == id).FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<StockDto> GetAllStock()
        {
            try
            {
                return this._context.STOCK.ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void SaveStock(StockDto stock)
        {
            try
            {
                this._context.STOCK.Add(stock);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateStock(StockDto stock)
        {
            try
            {
                this._context.Update(stock);
                this._context.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public long GetQR(StockDto stock)
        {
            try
            {
                QRDto QR;
                QR = this._context.QR.Where(x => x.IdStock == stock.ID).FirstOrDefault();
                if(QR == null)
                {
                    QR = new QRDto();
                    QR.IdStock = stock.ID;
                    this._context.QR.Add(QR);
                    this._context.SaveChanges();
                }             
               
                return QR.ID;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateQR(StockDto stock)
        {
            try
            {
              QRDto QR =  this._context.QR.Where(x => x.ID == long.Parse(stock.QR)).FirstOrDefault();
                QR.IdStock = stock.ID;
                this._context.QR.Update(QR);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Stock_StateDto> GetAllStates()
        {
            try
            {
              return  this._context.STOCK_STATE.ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void saveStockBySucursal(StockDto stock)
        {
            try
            {
                Stock_SucursalDto stockSucursal;
                var sucursalList = this._context.SUCURSAL.ToList();
                foreach (var item in sucursalList)
                {
                    stockSucursal = new Stock_SucursalDto();
                    stockSucursal.IdSucursal = item.ID;
                    stockSucursal.IdStock = stock.ID;
                    if (item.ID == stock.IdSucursal)
                    {                       
                        stockSucursal.Unity = stock.Unity;
                    }
                    else
                    {
                        stockSucursal.Unity = 0;
                    }
                    this._context.STOCK_SUCURSAL.Add(stockSucursal);
                    this._context.SaveChanges();
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Stock_SucursalDto> GetStockBySucursal(StockDto stock)
        {
            try
            {
              return  this._context.STOCK_SUCURSAL.Where(x => x.IdStock == stock.ID).ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
