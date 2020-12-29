using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Class
{
    public class UserGetDto: UserDto
    {
        public string RoleDescription { get { return Role.Description; } }
        public string OfficeName { get { return Office.Name; } }
    }
}
