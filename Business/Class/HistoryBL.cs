using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstantControl;
using System.Text;
using AutoMapper;
using Repository.Entities;
using StockManagerApi.Extensions;
using System.Threading.Tasks;

namespace Business.Class
{
    public class HistoryBL: IHistoryBL
    {
        private readonly IHistoryRep _historyRep;
        private readonly IUserRep _userhRep;
        private readonly IOfficeRep _officeRep;       
        private readonly IMapper _mapper;
        public HistoryBL(IHistoryRep historyRep, IUserRep userRep, IOfficeRep officeRep, IStockRep stockRep, IMapper mapper)
        {
            this._historyRep = historyRep;
            this._userhRep = userRep;
            this._officeRep = officeRep;            
            this._mapper = mapper;
        }
        /// <summary>
        /// Busca historial de eventos por sucursal
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResultDto<HistoryDto>> GetHistoryFilter(HistoryFilterDto dto)
        {          
            var result = await this._historyRep.GetHistoryFilter(dto, ContextProvider.OfficeId);

            return this._mapper.Map<ResultDto<HistoryDto>>(result);
        }
    }
}
