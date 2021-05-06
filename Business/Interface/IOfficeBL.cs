using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IOfficeBL
    {
        IEnumerable<OfficeDto> GetAllOffice();
        OfficeDto GetOfficeByName(string name);
        IEnumerable<OfficeDto> GetOfficesByCountry(int id);
        OfficeDto GetOfficeById(int id);
        Task<ResultDto<OfficeGetDto>> GetOfficeFilter(OfficeFilterDto dto);
        void Add(OfficeDto office);
        void Update(OfficeDto office);
        void Delete(int id);


    }
}
