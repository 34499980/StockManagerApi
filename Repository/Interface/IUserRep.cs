﻿using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IUserRep
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByUserName(string userName);
        User GetUserById(int id);
        void UpdateUser(User user);
        void SaveUser(User user);


    }
}
