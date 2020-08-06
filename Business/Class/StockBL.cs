using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
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
        public StockDto GetStockById(int id)
        {
            try
            {
                StockDto stock =  this._stockRep.GetStockById(id);
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
                StockDto inputStock = this._stockRep.GetStockById(stock.ID);
                if(inputStock == null)
                {
                  var user =  this._userRep.GetUserByUserName(userInput);
                  stock.IdSucursal = user.IdSucursal;
                  stock.QR = this._stockRep.GetQR(stock).ToString();
                  stock.IdState = this._stockRep.GetAllStates().Where(x => x.Description == "Habilitado").FirstOrDefault().ID;                  
                  this._stockRep.SaveStock(stock);
                  this._stockRep.saveStockBySucursal(stock);
                  this._stockRep.UpdateQR(stock);

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
                StockDto inputStock = this._stockRep.GetStockById(stock.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
