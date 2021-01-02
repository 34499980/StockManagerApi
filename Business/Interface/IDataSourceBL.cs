﻿using DTO.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IDataSourceBL
    {
        IEnumerable<CountryDto> GetAllCountries();
        IEnumerable<Dispatch_StateDto> GetAllDispatchState();
        IEnumerable<Stock_StateDto> GetAllStockState();
        IEnumerable<RolesDto> GetAllRoles();
    }
}