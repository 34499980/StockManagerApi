using AutoMapper;
using Business.Interface;
using DTO.Class;
using Repository.Entities;
using Repository.Interface;
using StockManagerApi.Extensions;
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
        public IEnumerable<UserGetDto> GetAllUsers()
        {
            try
            {
               var result = _userRep.GetAllUsers();
                return _mapper.Map<IEnumerable<UserGetDto>>(result);
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
        public UserGetDto GetUserById(int id)
        {
            try
            {                
              var result = _userRep.GetUserById(id);
                return _mapper.Map<UserGetDto>(result);
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
        public UserGetDto GetUserByName(string userName)
        {
            try
            {
                var result = _userRep.GetUserByUserName(userName);
                return _mapper.Map<UserGetDto>(result);
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

                var userModel = _userRep.GetUserByUserName(user.UserName);               
                _mapper.Map<UserDto, User>(user, userModel);
                
                this._userRep.UpdateUser(userModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RemoveUser(int id)
        {

            try
            {
                var userModel =_userRep.GetUserById(id);
                userModel.Active = false;
                _userRep.RemoveUser(userModel);             
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UserGetDto> GetUserFilter(UserFilterDto dto)
        {
            try
            {
                var result = this._userRep.GetUserFilter(dto);
               return _mapper.Map<IEnumerable<UserGetDto>>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public ImageDto GetImageByUser(string name)
        {
            try
            {
                var result = this._userRep.GetImageByUser(name);
                return new ImageDto { Image = result };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SetAuthorization(UserDto dto)
        {
            try
            {
                ContextProvider.RoleId = dto.IdRole;
                ContextProvider.SelectedCountry = dto.IdCountry;
                ContextProvider.UserId = dto.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
