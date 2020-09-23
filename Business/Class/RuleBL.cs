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
        public RuleBL(IRuleRep ruleRep)
        {
            this._ruleRep = ruleRep;

        }
        public IEnumerable<RulesDto> GetAllRules()
        {
            try
            {
                return this._ruleRep.GetAllRules();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
