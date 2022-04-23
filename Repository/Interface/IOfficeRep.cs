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
        Task<Office> GetOfficeById(int id);
        Task<Result<Office>> GetOfficeFilter(OfficeFilterDto dto);
        IEnumerable<Office> GetOfficesByCountry(int id);
        Task<IEnumerable<Office>> GetOfficeByName(string name, int idCountry);
        void Add(Office office);
        void Delete(Office office);
        void Update(Office office);
    }
}
