using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Repository.Class.Context;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Class
{
    public class OfficeRep: IOfficeRep
    {
        private readonly StockManagerContext _context;
        public OfficeRep(StockManagerContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Devuelve todas las sucursales
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Office> GetAllOffice()
        {
            try
            {
                return this._context.OFFICE.Include(x => x.Country).ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve la sucursal por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Office GetOfficeById(int id)
        {
            try
            {
                return this._context.OFFICE.Include(x => x.Country).Where(x => x.ID == id).FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve sucursal por nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Office GetOfficeByName(string name)
        {           
            try
            {
                 return this._context.OFFICE.Include(x => x.Country).Where(x => x.Name == name).FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve sucursales por pais 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Office> GetOfficesByCountry(int id)
        {
            try
            {
                return this._context.OFFICE.Where(x => x.IdCountry == id && x.Active).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add(Office office)
        {
            try
            {
                this._context.OFFICE.Add(office);
                this._context.SaveChanges();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public void Delete(Office office)
        {
            try
            {
                this._context.Entry(office).State = EntityState.Modified;
                this._context.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Update(Office office)
        {
            try
            {
                this._context.Entry(office).State = EntityState.Modified;
                this._context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Office> GetOfficeFilter(OfficeFilterDto dto)
        {
            try
            {
                var result = this._context.OFFICE.Include(x => x.Country).Where(x => (dto.Name == "" || x.Name.Contains(dto.Name)) &&
                                                        (dto.IdCountry == null || x.IdCountry == dto.IdCountry) &&
                                                        (dto.Address == "" || x.Address.Contains(dto.Address)) &&
                                                        (dto.PostalCode == null || x.PostalCode == dto.PostalCode) &&
                                                        (!dto.Active ? x.Active == true : (x.Active == true || x.Active == false))).ToList();
                                                        
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
