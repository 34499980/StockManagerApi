using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Repository.Class.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Class
{
    public class RuleRep : IRuleRep
    {
        private readonly StockManagerContext _context;
        public RuleRep(StockManagerContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Devuelve todos los roles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RulesDto> GetAllRules()
        {
            try
            {
                return _context.RULES.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
