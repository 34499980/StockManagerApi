using DTO.Class;
using Microsoft.EntityFrameworkCore;
using Repository.Class.Context;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Class
{
    public class HistoryRep : IHistoryRep
    {
        private readonly StockManagerContext _context;
        public HistoryRep(StockManagerContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Busca el historial por sucursal
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="idOffice"></param>
        /// <returns></returns>
        public async Task<Result<History>> GetHistoryFilter(HistoryFilterDto dto, int idOffice)
        {
            try
            {
                var query = this._context.HISTORY.Include(q => q.User)
                                                 .Include(q => q.Office)
                                                          .Where(x =>
                                                                (dto.UserName == "" || dto.UserName == null) || x.User.UserName.Contains(dto.UserName) &&
                                                                  (dto.UserName == "" || dto.UserName == null) || x.User.UserName.Contains(dto.UserName) &&
                                                                   (dto.DateproccesFrom == null || x.DateProces == dto.DateproccesFrom) &&
                                                                   (dto.DateproccesTo == null || x.DateProces == dto.DateproccesTo) &&
                                                                   (dto.Action == null || x.Action == dto.Action) &&                                                             
                                                               (x.IdOffice == idOffice)
                                                        );
                var page = await query.Skip((dto.PageIndex - 1) * dto.PageSize)
                     .Take(dto.PageSize)
                    .ToListAsync();

                return new Result<History> { rowCount = query.Count(), data = page };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Agrega al historial un nuevo movimiento hecho por alguno usuario de su sucursal
        /// </summary>
        /// <param name="action"></param>
        /// <param name="actionDetail"></param>
        /// <param name="IdOffice"></param>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        public History AddHistory(string action, string actionDetail, int IdOffice, int IdUser)
        {
            try
            {
                History history = new History()
                {
                    DateProces = DateTime.Now,
                    Action = action,
                    ActionDetail = actionDetail,
                    IdOffice = IdOffice,
                    IdUser = IdUser
                };
                this._context.HISTORY.Add(history);
                this._context.SaveChanges();
                return history;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
