using AutoMapper;
using Business.Interface;
using DTO.Class;
using Repository.Entities;
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
        private readonly IMapper _mapper;
        public UsersBL(IUserRep userRep, IMapper mapper)
        {
            this._userRep = userRep;
            this._mapper = mapper;
        }
        /// <summary>
        /// Trae todos los usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDto> GetAllUsers()
        {
            try
            {
               var result = _userRep.GetAllUsers();
                return _mapper.Map<IEnumerable<UserDto>>(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Devuelve usuario por id.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserDto GetUserById(int id)
        {
            try
            {                
              var result = _userRep.GetUserById(id);
                return _mapper.Map<UserDto>(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve usuario por nickName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserDto GetUserByName(string userName)
        {
            try
            {
                var result = _userRep.GetUserByUserName(userName);
                return _mapper.Map<UserDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Guardar usuario nuevo
        /// </summary>
        /// <param name="user"></param>
        public void SaveUser(UserDto user)
        {
            try
            {
                var userInput = _mapper.Map<User>(user);
                this._userRep.SaveUser(userInput);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza usuario
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(UserDto user)
        {
            try
            {
                var userInput = _mapper.Map<User>(user);
                this._userRep.UpdateUser(userInput);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
