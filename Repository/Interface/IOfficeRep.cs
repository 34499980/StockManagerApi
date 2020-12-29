using DTO.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IOfficeRep
    {
        IEnumerable<Office> GetAllOffice();
        Office GetOfficeById(int id);
    }
}
