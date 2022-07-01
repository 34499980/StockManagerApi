using AutoMapper;
using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DashboardBL : IDashboardBL
    {
        private readonly IDashboardRep _dashboardRep;
        private readonly IMapper _mapper;
        public DashboardBL(IDashboardRep dashboardRep, IMapper mapper)
        {
            _dashboardRep = dashboardRep;
            _mapper = mapper;
        }
        public async Task<DashboardDto> GetDataChart(DashboardFilterDto dto)
        {
            try
            {
                var dataEntity = await _dashboardRep.GetDataChart(dto.DateFrom, dto.DateTo, dto.OfficeId);
                var data = _mapper.Map<List<DashboardDataDto>>(dataEntity);                


                string[] columnsName = new string[] { "Days", "Count" };
                return new DashboardDto() { ColumnsName = columnsName, Data = data };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
