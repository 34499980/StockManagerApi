using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryBL _historyBL;
        public HistoryController(IHistoryBL historyBL)
        {
            this._historyBL = historyBL;
        }

        [HttpPost("GetHistoryFilter")]
        [Authorize]
        public async Task<ResultDto<HistoryDto>> Get(HistoryFilterDto dto)
        {
            try
            {
                return await this._historyBL.GetHistoryFilter(dto);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


    }
}
