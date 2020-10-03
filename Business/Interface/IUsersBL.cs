using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IUsersBL
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserByName(string userName);
        UserDto GetUserById(int id);
        void UpdateUser(UserDto user);
        void SaveUser(UserDto user);

    }
}
