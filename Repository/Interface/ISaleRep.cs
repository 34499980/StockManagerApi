using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ISaleRep
    {
        Task<Sale> save(Sale sale);
    }
}
