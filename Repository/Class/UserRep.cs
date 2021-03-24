using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Repository.Class.Context;
using Repository.Entities;
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
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _context.USERS.Include(x => x.Role)
                                     .Include(x => x.Office)
                                     .Include(q => q.Country).ToList();
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
        public User GetUserByUserName(string userName)
        {
            try
            {                
              var result =  _context.USERS.Include(q => q.Office)
                                          .Include(q => q.Role) 
                                          .Include(q => q.Country)
                                          .Where(x => x.UserName == userName).FirstOrDefault();
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            try
            {
                var result = _context.USERS.Include(q => q.Office)
                                           .Include(q => q.Role)
                                           .Include(q => q.Country)
                                           .Where(x => x.ID == id).FirstOrDefault();
                return result;
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
        public void SaveUser(User user)
        {
            try
            {
                this._context.USERS.Add(user);
                this._context.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza usuario
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            try
            {
                this._context.Entry(user).State = EntityState.Modified;
                this._context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Remove user
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            try
            {              
                this._context.Entry(user).State = EntityState.Modified;
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetUserFilter(UserFilterDto dto)
        {
            try
            {
              var result  =  this._context.USERS.Include(q => q.Office)
                                                .Include(q => q.Role)
                                                .Include(q => q.Country)
                                                .Where(x => (dto.UserName == "" || x.UserName.Contains(dto.UserName)) &&
                                                      (dto.IdRole == null || x.IdRole == dto.IdRole) &&
                                                       (dto.IdCountry == null || x.IdCountry == dto.IdCountry) &&
                                                      (dto.IdOffice == null || x.IdOffice == dto.IdOffice) &&
                                                      (!dto.Active? x.Active == true: (x.Active == true || x.Active == false))
                                                      ).ToListAsync();
                return result.Result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string GetImageByUser(string name)
        {
            try
            {
                return this._context.USERS.Where(q => q.UserName == name).FirstOrDefault()?.File; ;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
