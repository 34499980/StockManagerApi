﻿using DTO.Class;
using Repository.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IHistoryRep
    {
        Task<Result<History>> GetHistoryFilter(HistoryFilterDto dto, int idOffice);
        History AddHistory(string action, string actionDetail, int IdOffice, int IdUser);
    }
}
