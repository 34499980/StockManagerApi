﻿using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
        public IEnumerable<StockDto> GetStockByCode(string qr)
        {
            try
            {
                return this._context.STOCK.Where(x => x.QR == qr).ToList();
            } catch (Exception ex)
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
            } catch (Exception ex)
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
            } catch (Exception ex)
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
                return this._context.STOCK_STATE.ToList();
            } catch (Exception ex)
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

            } catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve todas las unidades de stock que tiene por sucursal
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public Stock_SucursalDto GetStock_Sucursal(long idStock, int idSucursal)
        {
            try
            {
                var result = this._context.STOCK_SUCURSAL.Where(x => x.IdStock == idStock && x.IdSucursal == idSucursal).FirstOrDefault();
                return result;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Stock_SucursalDto> GetStockSucursalByIdStock(StockDto stock)
        {
            try
            {
                var result = this._context.STOCK_SUCURSAL.Where(x => x.IdStock == stock.ID ).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve un listado de stock por parametros puestos en un where
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<StockDto> GetStockByParams(string param,string name)
        {
            try
            {              
                var result = this._context.STOCK.FromSqlRaw<StockDto>(name, param).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualizo unidades de stock por sucursal
        /// </summary>
        /// <param name="stock"></param>
        public void UpdateStockBySucursal(Stock_SucursalDto stock)
        {
            try
            {
                this._context.Entry(stock).State = EntityState.Modified;               
                this._context.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve stock por el id de base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

       
    }
}
