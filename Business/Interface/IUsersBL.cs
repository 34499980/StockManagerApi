using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IUsersBL
    {
        IEnumerable<UserGetDto> GetAllUsers();
        UserGetDto GetUserByName(string userName);
        UserGetDto GetUserById(int id);
        void UpdateUser(UserDto user);
        void SaveUser(UserDto user);
        void RemoveUser(int user);
        Task<IEnumerable<UserGetDto>> GetUserFilter(UserFilterDto dto);
        ImageDto GetImageByUser(string name);
        void SetAuthorization(UserDto dto);
        bool Validate(UserDto dto);
        void UpdateUserLenguage(UserLenguageDto dto);

    }
}
