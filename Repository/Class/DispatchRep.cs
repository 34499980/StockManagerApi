using DTO.Class;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{
    public class DispatchRep : IDispatchRep
    {
        private readonly StockManagerContext _context;
        public DispatchRep(StockManagerContext context)
        {
            this._context = context;
        }
        public int saveDispatch(DispatchDto dispatch)
        {
            try
            {
                this._context.DISPATCH.Add(dispatch);
                this._context.SaveChanges();
                return dispatch.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Dispatch_StateDto> GetStates()
        {
            try
            {
                return this._context.DISPATCH_STATE.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
