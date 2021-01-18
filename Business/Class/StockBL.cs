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
        private readonly IOfficeRep _officeRep;
        public StockBL(IStockRep stockRep,IUserRep userRep, IOfficeRep officeRep, IMapper mapper)
        {
            this._stockRep = stockRep;
            this._userRep = userRep;
            this._officeRep = officeRep;
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
        public StockDto GetStockById(int id)
        {
            try
            {
                var result = this._stockRep.GetStockById(id);
                return _mapper.Map<StockDto>(result);
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
        public void SaveStock(StockDto stock, int idCountry)
        {
            try
            {
                var inputStock = _mapper.Map<Stock>(stock);
                Stock inputDb = this._stockRep.GetStockByCode(stock.Code).FirstOrDefault();
                //var user = this._userRep.GetUserByUserName(userInput);
                if (inputDb == null)
                {

                    // stock.IdOffice = user.IdOffice;
                    inputStock.QR = stock.Code;
                    var offices = _officeRep.GetOfficesByCountry(idCountry);
                    List<Stock_Office> stock_officeList = new List<Stock_Office>();
                    foreach (var item in offices)
                    {

                        if (!stock.Stock_Office.Any(x => x.IdOffice == item.ID))
                        {
                            inputStock.Stock_Office.Add(new Stock_Office() { IdOffice = item.ID, Unity = 0 });
                        }
                    }
                    //  stock.IdState = this._stockRep.GetAllStates().Where(x => x.ID == (int)Constants.Stock_State.Habilitado).FirstOrDefault().ID;                  
                    long idStock = this._stockRep.SaveStock(inputStock);

                   /* var offices = _officeRep.GetOfficesByCountry(idCountry);
                    List<Stock_Office> stock_officeList = new List<Stock_Office>();
                    foreach (var item in offices)
                    {

                        if (!stock.Stock_Office.Any(x => x.IdOffice == item.ID))
                        {
                            stock_officeList.Add(new Stock_Office() { IdOffice = item.ID, IdStock = idStock, Unity = 0 });
                        }
                    }
                    foreach (var item in stock.Stock_Office)
                    {
                        item.IdStock = idStock;

                    }
                    var inputStock_Office = _mapper.Map<IEnumerable<Stock_Office>>(stock.Stock_Office);
                    var stock_OfficeListMerged  = stock_officeList.Concat(inputStock_Office).ToArray();
                    this._stockRep.saveStockByOffice(stock_OfficeListMerged);*/
                 // this._stockRep.UpdateQR(stock);

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
        public void UpdateStock(StockDto stock)
        {
            try
            {
                var inputSock = _mapper.Map<Stock>(stock);
                this._stockRep.UpdateStock(inputSock);
                this._stockRep.UpdateStockByOffice(inputSock.Stock_Office);
                
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
        public IEnumerable<Stock_OfficeDto> GetStockFilter(StockFilterDto dto)
        {
            try
            {
                var stockList = this._stockRep.GetOfficeFilter(dto);
               
                return _mapper.Map<IEnumerable<Stock_OfficeDto>>(stockList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(int id)
        {
            try
            {
                 this._stockRep.delete(id);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
