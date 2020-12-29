using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ConstantControl;
using Repository.Entities;
using AutoMapper;

namespace Business.Class
{
    public class StockBL : IStockBL
    {
        private readonly IStockRep _stockRep;
        private readonly IUserRep _userRep;
        private readonly IMapper _mapper;
        public StockBL(IStockRep stockRep,IUserRep userRep, IMapper mapper)
        {
            this._stockRep = stockRep;
            this._userRep = userRep;
            this._mapper = mapper;
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
                if (listStock != null)
                {
                    foreach (var item in listStock)
                    {
                        item.Stock_Office = this._stockRep.GetStockOfficeByIdStock(item);
                    }

                }

                return _mapper.Map<IEnumerable<StockDto>>(listStock);
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
                var result = this._stockRep.GetAllStock();
                return _mapper.Map<IEnumerable<StockDto>>(result);
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
                var inputStock = _mapper.Map<Stock>(stock);
                Stock inputDb = this._stockRep.GetStockByCode(stock.QR).FirstOrDefault();
                var user = this._userRep.GetUserByUserName(userInput);
                if (inputDb == null)
                {
                 
                  stock.IdOffice = user.IdOffice;
                  stock.Code = stock.QR;
                  stock.IdState = this._stockRep.GetAllStates().Where(x => x.ID == (int)Constants.Stock_State.Habilitado).FirstOrDefault().ID;                  
                  this._stockRep.SaveStock(inputStock);
                  this._stockRep.saveStockByOffice(inputStock);
                 // this._stockRep.UpdateQR(stock);

                }
                else
                {
                    foreach (var item in inputStock.Stock_Office)
                    {
                        if(item.IdOffice == user.IdOffice)
                        {
                            this._stockRep.UpdateStockByOffice(item);
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
                var inputSock = _mapper.Map<Stock>(stock);
                Stock_Office stock_Sucursal =  this._stockRep.GetStockOfficeByIdStock(inputSock).Where(x => x.IdStock == stock.ID && x.IdOffice == stock.IdOffice).FirstOrDefault();
                stock_Sucursal.Unity = stock.Unity;
                this._stockRep.UpdateStockByOffice(stock_Sucursal);
                this._stockRep.UpdateStock(inputSock);
                
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
                   item.Stock_Office = this._stockRep.GetStockOfficeByIdStock(item);                   
                }
                return _mapper.Map<IEnumerable<StockDto>>(result);
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
             var result =  this._stockRep.GetAllStates();
                return _mapper.Map<IEnumerable<Stock_StateDto>>(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
