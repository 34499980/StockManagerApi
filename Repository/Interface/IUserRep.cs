using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IUserRep
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserByUserName(string userName);
        UserDto GetUserById(int id);
      
    }
}
