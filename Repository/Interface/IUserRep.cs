using DTO.Class;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRep
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByUserName(string userName);
        User GetUserById(int id);
        void UpdateUser(User user);
        void SaveUser(User user);
        void RemoveUser(User id);
        Task<IEnumerable<User>> GetUserFilter(UserFilterDto dto);
        string GetImageByUser(string name);
        IEnumerable<Permission> getPermissionsByIdRole(int id);


    }
}
