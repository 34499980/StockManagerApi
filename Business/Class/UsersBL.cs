using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Business.Class
{
    public class UsersBL: IUsersBL
    {
        private readonly IUserRep _userRep;
        public UsersBL(IUserRep userRep)
        {
            this._userRep = userRep;
        }
        /// <summary>
        /// Trae todos los usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDto> GetAllUsers()
        {
            try
            {
               return _userRep.GetAllUsers();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Trae los usuarios por nombre de usuario.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserDto GetUserById(string userName)
        {
            try
            {
              return _userRep.GetUserById(userName);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
