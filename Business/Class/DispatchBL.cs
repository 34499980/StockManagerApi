﻿using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Class
{
    public class DispatchBL: IDispatchBL
    {
        private readonly IDispatchRep _dispatchRep;
        private readonly IUserRep _userhRep;
        private readonly ISucursalRep _sucursalRep;
        private readonly IStockRep _stockRep;
        public DispatchBL(IDispatchRep dispatchRep, IUserRep userRep, ISucursalRep sucursalRep, IStockRep stockRep)
        {
            this._dispatchRep = dispatchRep;
            this._userhRep = userRep;
            this._sucursalRep = sucursalRep;
            this._stockRep = stockRep;
        }
        /// <summary>
        /// Guarda despacho nuevo
        /// </summary>
        /// <param name="dispatch"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public DispatchDto saveDispatch(DispatchDto dispatch,string user)
        {
            try
            {
              
                DispatchDto result = this._dispatchRep.GetDispatchBySucursales(dispatch);
                if(result == null)
                {                 
                    dispatch.IdUser = this._userhRep.GetUserByUserName(user).ID;
                    dispatch.DateCreate = DateTime.Now;
                    dispatch.IdState = this._dispatchRep.GetStates().Where(x => x.Description == "Creado").FirstOrDefault().ID;
                    dispatch.Unity = 0;
                    result = this._dispatchRep.saveDispatch(dispatch);
                }
                else
                {
                  result = GetDispatchById(result.ID);
                }

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Trae todos los estados de un despacho
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Dispatch_StateDto> GetStates()
        {
            try
            {
                return this._dispatchRep.GetStates();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve todos los despachos
        /// </summary>
        /// <returns></returns>

        public IEnumerable<DispatchDto> GetAllDispatches()
        {
            try
            {
                var listDispatches = this._dispatchRep.GetAllDispatches();
                foreach (var item in listDispatches)
                {                    
                    item.Usuario = this._userhRep.GetUserById(item.IdUser);
                    item.SucDestiny = this._sucursalRep.GetSucursalById(item.Destiny);
                    item.SucOrigin = this._sucursalRep.GetSucursalById(item.Origin);
                    item.State = this._dispatchRep.GetStates().Where(x => x.ID == item.IdState).FirstOrDefault(); ;
                }
                return listDispatches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Busca despacho por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public DispatchDto GetDispatchById(int id)
        {
            try
            {
                DispatchDto dispatch =  this._dispatchRep.GetDispatchById(id);
                dispatch.Usuario = this._userhRep.GetUserById(dispatch.IdUser);
                dispatch.Stock = this._dispatchRep.GetStockIdByDispatch(dispatch.ID);
                foreach (var item in dispatch.Stock)
                {
                  item.Stock_Sucursal =  this._stockRep.GetStockBySucursal(item);
                  
                }
              

               
                return dispatch;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
