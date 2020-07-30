using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Class
{
    public class DispatchBL: IDispatchBL
    {
        private readonly IDispatchRep _dispatchRep;
        private readonly IUserRep _userhRep;
        public DispatchBL(IDispatchRep dispatchRep, IUserRep userRep)
        {
            this._dispatchRep = dispatchRep;
            this._userhRep = userRep;
        }
        public int saveDispatch(DispatchDto dispatch)
        {
            try
            {
              dispatch.IdUser =  this._userhRep.GetUserById(dispatch.IdUser).ID.ToString();
                dispatch.DateCreate = DateTime.Now;
               return  this._dispatchRep.saveDispatch(dispatch);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
