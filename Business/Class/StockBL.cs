using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ConstantControl;

namespace Business.Class
{
    public class StockBL : IStockBL
    {
        private readonly IStockRep _stockRep;
        private readonly IUserRep _userRep;
        public StockBL(IStockRep stockRep,IUserRep userRep)
        {
            this._stockRep = stockRep;
            this._userRep = userRep;
        }
        /// <summary>
        /// Devuelve stock por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<StockDto> GetStockByCode(string code)
        {
            try
            {
                var listStock =  this._stockRep.GetStockByCode(code);
                if(listStock != null)
                {
                    foreach (var item in listStock)
                    {
                        item.Stock_Sucursal = this._stockRep.GetStockSucursalByIdStock(item);
                    }
                    
                }
               
                return listStock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve todo el stock
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StockDto> GetAllStock()
        {
            try
            {
                return this._stockRep.GetAllStock();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Guarda el nuevo stock
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="userInput"></param>
        public void SaveStock(StockDto stock,string userInput)
        {
            try
            {
                StockDto inputStock = this._stockRep.GetStockByCode(stock.QR).FirstOrDefault();
                var user = this._userRep.GetUserByUserName(userInput);
                if (inputStock == null)
                {
                 
                  stock.IdSucursal = user.IdSucursal;
                  stock.Code = stock.QR;
                  stock.IdState = this._stockRep.GetAllStates().Where(x => x.ID == (int)Constants.Stock_State.Habilitado).FirstOrDefault().ID;                  
                  this._stockRep.SaveStock(stock);
                  this._stockRep.saveStockBySucursal(stock);
                 // this._stockRep.UpdateQR(stock);

                }
                else
                {
                    foreach (var item in stock.Stock_Sucursal)
                    {
                        if(item.IdSucursal == user.IdSucursal)
                        {
                            this._stockRep.UpdateStockBySucursal(item);
                        }

                    }
                    //this._stockRep.UpdateStock(stock);
                }
                
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
        /// <param name="user"></param>
        public void UpdateStock(StockDto stock,string user)
        {
            try
            {
               // StockDto inputStock = this._stockRep.GetStockByCode(stock.QR).FirstOrDefault();
                //UserDto  userId = this._userRep.GetUserByUserName(user);
                Stock_SucursalDto stock_Sucursal =  this._stockRep.GetStockSucursalByIdStock(stock).Where(x => x.IdStock == stock.ID && x.IdSucursal == stock.IdSucursal).FirstOrDefault();
                stock_Sucursal.Unity = stock.Unity;
                this._stockRep.UpdateStockBySucursal(stock_Sucursal);
                this._stockRep.UpdateStock(stock);
                
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
        public IEnumerable<StockDto> GetStockByParams(string param)
        {
            try
            {                
                var result =  this._stockRep.GetStockByParams(param, "Get_StockByParameters {0}");
                foreach (var item in result)
                {
                   item.Stock_Sucursal = this._stockRep.GetStockSucursalByIdStock(item);                   
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve todos los estados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock_StateDto> GetStates()
        {
            try
            {
             return  this._stockRep.GetAllStates();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
