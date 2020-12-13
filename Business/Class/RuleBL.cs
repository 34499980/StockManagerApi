using AutoMapper;
using Business.Interface;
using DTO.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Class
{
    public class RuleBL :IRuleBL
    {
        private readonly IRuleRep _ruleRep;
        private readonly IMapper _mapper;
        public RuleBL(IRuleRep ruleRep, IMapper mapper)
        {
            this._ruleRep = ruleRep;
            this._mapper = mapper;

        }
        public IEnumerable<RolesDto> GetAllRules()
        {
            try
            {
                var result = this._ruleRep.GetAllRules();
                return _mapper.Map<IEnumerable<RolesDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
