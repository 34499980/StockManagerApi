using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

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
        public StockDto GetStockByCode(string code)
        {
            try
            {
                StockDto stock =  this._stockRep.GetStockByCode(code);
                if(stock != null)
                {
                    stock.Stock_Sucursal = this._stockRep.GetStockBySucursal(stock);
                }
               
                return stock;
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
                StockDto inputStock = this._stockRep.GetStockByCode(stock.QR);
                if(inputStock == null)
                {
                  var user =  this._userRep.GetUserByUserName(userInput);
                  stock.IdSucursal = user.IdSucursal;
                  stock.Code = stock.QR;
                  stock.IdState = this._stockRep.GetAllStates().Where(x => x.Description == "Habilitado").FirstOrDefault().ID;                  
                  this._stockRep.SaveStock(stock);
                  this._stockRep.saveStockBySucursal(stock);
                 // this._stockRep.UpdateQR(stock);

                }
                else
                {

                    this._stockRep.UpdateStock(stock);
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
                StockDto inputStock = this._stockRep.GetStockByCode(stock.QR);
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
                List<SqlParameter> listParameters = new List<SqlParameter>();
                listParameters.Add(new SqlParameter("@param", param));
                return this._stockRep.GetStockByParams(listParameters.ToArray(), "Get_StockByParameters");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
