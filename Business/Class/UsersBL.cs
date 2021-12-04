using AutoMapper;
using Business.Interface;
using ConstantControl;
using DTO.Class;
using Repository.Entities;
using Repository.Interface;
using StockManagerApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public class UsersBL: IUsersBL
    {
        private readonly IUserRep _userRep;
        private readonly IMapper _mapper;
        private readonly IDataSourceRep _dataSourceRep;
        private readonly IHistoryRep _historyRep;
        public UsersBL(IUserRep userRep, IMapper mapper, IDataSourceRep dataSourceRep, IHistoryRep historyRep)
        {
            this._userRep = userRep;
            this._dataSourceRep = dataSourceRep;
            this._historyRep = historyRep;
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
                if (result == null) return null;
                var userModel =  _mapper.Map<UserGetDto>(result);
                userModel.Permissions = _mapper.Map<IEnumerable<PermissionDto>>(_userRep.getPermissionsByIdRole(result.IdRole));
                return userModel;
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
                var countries = (ICollection<Country>)_dataSourceRep.GetAllCountries();
                userInput.Lenguage = countries.Where(x => x.ID == userInput.IdCountry).FirstOrDefault().Language;
                this._userRep.SaveUser(userInput);
                this._historyRep.AddHistory((int)Constants.Actions.Users ,Constants.HistoryUserCreate, user.UserName, user.IdOffice, ContextProvider.UserId);
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
                user.Lenguage = userModel.Lenguage;
                _mapper.Map<UserDto, User>(user, userModel);
                
                this._userRep.UpdateUser(userModel);
                this._historyRep.AddHistory((int)Constants.Actions.Users ,Constants.HistoryUserUpdate, user.UserName, user.IdOffice, ContextProvider.UserId);
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
                this._historyRep.AddHistory((int)Constants.Actions.Users ,Constants.HistoryUserDelete, userModel.UserName, userModel.IdOffice, ContextProvider.UserId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserGetDto>> GetUserFilter(UserFilterDto dto)
        {
            try
            {
                var result = await this._userRep.GetUserFilter(dto);
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
                ContextProvider.OfficeId = dto.IdOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Validate(UserDto dto)
        {
            try
            {
               var userDB = _userRep.GetUserByUserName(dto.UserName);
                if(userDB == null) throw new Business.Exceptions.BussinessException(Constants.ErrUserOrPass);

                if (userDB.UserName == dto.UserName && userDB.Password == dto.Password &&
                    userDB.IdRole == (int)ConstantControl.Constants.RoleEnum.Administrative ||
                     userDB.IdRole == (int)ConstantControl.Constants.RoleEnum.Manager)
                {
                    return true;
                }
                else
                {
                    throw new Business.Exceptions.BussinessException(Constants.ErrUserOrPass);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateUserLenguage(UserLenguageDto dto)
        {
            try
            {
                var user = _userRep.GetUserById(dto.UserId);
                user.Lenguage = dto.Lenguage;
                _userRep.UpdateUser(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
