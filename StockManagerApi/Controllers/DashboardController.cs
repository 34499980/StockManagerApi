using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using DTO.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardBL _dashboardBL;
        public DashboardController(IDashboardBL dashboardBL)
        {
            this._dashboardBL = dashboardBL;
        }

        [HttpPost("GetDataChart")]
        [Authorize]
        public async Task<DashboardDto> GetDataChart(DashboardFilterDto dto)
        {
            try
            {
              return await  this._dashboardBL.GetDataChart(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
