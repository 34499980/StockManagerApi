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
        /// <summary>
        /// Busca el stock por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StockDto GetStockByCode(string code)
        {
            try
            {
                return this._context.STOCK.Where(x => x.QR == code).FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Busca todo el stock
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Guarda el stock nuevo
        /// </summary>
        /// <param name="stock"></param>
        public void SaveStock(StockDto stock)
        {
            try
            {
                this._context.STOCK.Add(stock);
                this._context.SaveChanges();
                stock.Code = stock.ID.ToString().PadLeft(10, '0');
                this.UpdateStock(stock);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza los datos de stock
        /// </summary>
        /// <param name="stock"></param>
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
        /// <summary>
        /// Ingresa un codigo QR por stock. Si ya posee uno, devuelve ese.
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Actualiza la relacion de QR-Stock ingresado el stock generado
        /// </summary>
        /// <param name="stock"></param>
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
        /// <summary>
        /// Devuelve los estados que puede tener el stock
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Al crear el stock, se genera por cada sucursal por lo menos con valor 0
        /// </summary>
        /// <param name="stock"></param>
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
        /// <summary>
        /// Devuelve todas las unidades de stock que tiene por sucursal
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
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
