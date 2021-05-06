using DTO.Class;
using Repository.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOfficeRep
    {
        IEnumerable<Office> GetAllOffice();
        Office GetOfficeById(int id);
        Task<Result<Office>> GetOfficeFilter(OfficeFilterDto dto);
        IEnumerable<Office> GetOfficesByCountry(int id);
        Office GetOfficeByName(string name);
        void Add(Office office);
        void Delete(Office office);
        void Update(Office office);
    }
}
