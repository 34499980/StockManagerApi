using Business.Interface;
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
        public DispatchBL(IDispatchRep dispatchRep, IUserRep userRep)
        {
            this._dispatchRep = dispatchRep;
            this._userhRep = userRep;
        }
        public int saveDispatch(DispatchDto dispatch)
        {
            try
            {
              dispatch.IdUser =  this._userhRep.GetUserById(dispatch.User).ID;
                dispatch.DateCreate = DateTime.Now;
                dispatch.IdState = this._dispatchRep.GetStates().Where(x => x.Description == "Creado").FirstOrDefault().ID;
               return  this._dispatchRep.saveDispatch(dispatch);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

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
    }
}
