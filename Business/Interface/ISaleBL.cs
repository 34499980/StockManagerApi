using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface ISaleBL
    {
        SaleDto save(SaleDto dto);
    }
}
