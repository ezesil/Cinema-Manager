﻿using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    public class UserAdapter : IGenericAdapter<User>
    {
        public User Adapt(object[] values)
        {
            return new User()
            {
                Id = Guid.Parse(values[0].ToString()),
                Username = (string)values[1],
                HashedPassword = (string)values[2],
                Email = (string)values[3],
                Enabled = (bool)values[4],
                DVH = (int)values[5],
                FullName = (string)values[6],
                DNI = (string)values[7]
            };
        }
    }
}
