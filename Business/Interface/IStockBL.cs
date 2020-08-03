﻿using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IStockBL
    {
        StockDto GetStockById(int id);
        IEnumerable<StockDto> GetAllStock();
    }
}