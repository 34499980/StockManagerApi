using DTO.Class;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{
    public class UserRep: IUserRep
    {
        private readonly StockManagerContext _context;
        public UserRep(StockManagerContext context)
        {
            this._context = context;
        }
        public IEnumerable<UserDto> GetAllUsers()
        {
            try
            {
                return _context.USUARIO.ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
