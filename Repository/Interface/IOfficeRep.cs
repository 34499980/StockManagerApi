using DTO.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IOfficeRep
    {
        IEnumerable<Office> GetAllOffice();
        Office GetOfficeById(int id);
        IEnumerable<Office> GetOfficeFilter(OfficeFilterDto dto);
        Office GetOfficeByName(string name);
        void Add(Office office);
        void Delete(Office office);
        void Update(Office office);
    }
}
