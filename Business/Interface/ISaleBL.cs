using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ISaleBL
    {
        Task save(SaleDto dto);
    }
}
