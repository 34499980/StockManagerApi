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
        Task<IEnumerable<OfficeDto>> GetOfficeByName(string name);
        IEnumerable<OfficeDto> GetOfficesByCountry(int id);
        OfficeDto GetOfficeById(int id);
        Task<ResultDto<OfficeGetDto>> GetOfficeFilter(OfficeFilterDto dto);
        Task Add(OfficeDto office);
        Task Update(OfficeDto office);
        Task Delete(int id);
        Task<IEnumerable<ItemDto>> GetOfficeChipByName(string name);
        IEnumerable<ItemDto> GetOfficesChipByCountry();

    }
}
