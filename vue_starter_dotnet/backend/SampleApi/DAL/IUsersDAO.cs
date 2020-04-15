﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApproval.Models;

namespace ProductApproval.DAL
{
    public interface IUsersDAO
    {
        User AddUser(User user);
        User DeleteUser(User user);
        User UpdateUser(User user);
        IList<User> GetAllUsers();
        //bool IsUsernameAndPasswordValid();
    }
}
