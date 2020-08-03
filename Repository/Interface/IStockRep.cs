﻿using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IStockRep
    {
        StockDto GetStockById(long id);
        IEnumerable<StockDto> GetAllStock();
    }
}