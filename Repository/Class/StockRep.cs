﻿using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Repository.Class.Context;
using Repository.Entities;
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
        public IEnumerable<Stock> GetStockByCode(string qr)
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
        public IEnumerable<Stock> GetAllStock()
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
        public long SaveStock(Stock stock)
        {
            try
            {
                this._context.STOCK.Add(stock);
                this._context.SaveChanges();

                return stock.ID;
                
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
        public void UpdateStock(Stock stock)
        {
            try
            {
                this._context.Entry(stock).State = EntityState.Modified;               
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
        public IEnumerable<Stock_State> GetAllStates()
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
        public void saveStockByOffice(IEnumerable<Stock_Office> stock_officeList)
        {
            try
            {
               
                    this._context.STOCK_OFFICE.AddRange(stock_officeList);
                    this._context.SaveChanges();
                
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
        public Stock_Office GetStock_Office(long idStock, int idSucursal)
        {
            try
            {
                var result = this._context.STOCK_OFFICE.Where(x => x.IdStock == idStock && x.IdOffice == idSucursal).FirstOrDefault();
                return result;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve el stock de todas las sucursales por un idstock
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public ICollection<Stock_Office> GetStockOfficeByIdStock(Stock stock)
        {
            try
            {
                var result = this._context.STOCK_OFFICE.Where(x => x.IdStock == stock.ID ).ToList();
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
        public IEnumerable<Stock> GetStockByParams(string param,string name)
        {
            try
            {              
                var result = this._context.STOCK.FromSqlRaw<Stock>(name, param).ToList();
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
        public  void UpdateStockByOffice(Stock_Office stock)
        {
            try
            {
                //var result = this._context.STOCK_SUCURSAL.ToList();
                var stockDB = this._context.STOCK_OFFICE.Where(x => x.IdStock == stock.IdStock && x.IdOffice == stock.IdOffice).FirstOrDefault();
                //var stock1 = this._context.STOCK_SUCURSAL.Where(x => x.IdStock == 1 && x.IdSucursal == 1).FirstOrDefault();
                //var stock2 = this._context.STOCK_SUCURSAL.Where(x => x.IdStock == 2 && x.IdSucursal == 1).FirstOrDefault();
                stockDB.Unity = stock.Unity;
                //this._context.STOCK_SUCURSAL.Remove(stockDB);
                this._context.Entry(stockDB).State = EntityState.Modified;
                //this._context.STOCK_SUCURSAL.UpdateRange(stockDB);              
                //this._context.SaveChanges();
                //this._context.STOCK_SUCURSAL.Add(stock);
                 this._context.SaveChanges();
               

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve stock por el id de base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Stock GetStockById(long id)
        {
            try
            {
                return this._context.STOCK.Include(x => x.Stock_Office).Where(x => x.ID == id).FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Stock> GetOfficeFilter(StockFilterDto dto)
        {
            try
            {
                var result = this._context.STOCK.Where(x => (dto.Name == "" || x.Name.Contains(dto.Name)) &&
                                                        (dto.Code == "" || x.Code.Contains(dto.Code)) &&
                                                        (dto.Brand == "" || x.Brand.Contains(dto.Brand)) &&
                                                        (dto.Model == "" || x.Model.Contains(dto.Model)) &&
                                                        (dto.IdOffice == null || x.IdOffice == dto.IdOffice) &&
                                                         (dto.IdCountry == null || x.Office.IdCountry == dto.IdOffice)).ToList();
                                                     

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
