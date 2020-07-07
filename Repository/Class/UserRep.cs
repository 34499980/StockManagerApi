﻿using DTO.Class;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// <summary>
        /// Trae todos los usuarios
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Trae el usuario por su nombre de usuario.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserDto GetUserById(string userName)
        {
            try
            {
              var result =  _context.USUARIO.Where(x => x.UserName == userName).FirstOrDefault();
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
