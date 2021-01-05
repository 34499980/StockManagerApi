using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IOfficeBL
    {
        IEnumerable<OfficeDto> GetAllOffice();
        OfficeDto GetOfficeByName(string name);
        IEnumerable<OfficeDto> GetOfficesByCountry(int id);
        OfficeDto GetOfficeById(int id);
        IEnumerable<OfficeGetDto> GetOfficeFilter(OfficeFilterDto dto);
        void Add(OfficeDto office);
        void Update(OfficeDto office);
        void Delete(int id);


    }
}
