﻿using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IUsersBL
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(string userName);
    }
}