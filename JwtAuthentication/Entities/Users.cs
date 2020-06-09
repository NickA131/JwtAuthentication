using JwtAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Entities
{
    public static class Users
    {
        public static List<User> GetAll()
        {
            // Ordinarily these would be sotred in an RDBMS
            // Here they are hard-coded for simplicity
            return new List<User>
            {
                new User { Id = 1, UserName = "nick", Password = "password", Role = Roles.Admin },
                new User { Id = 2, UserName = "fred", Password = "password", Role = Roles.User }
            };
        }


    }
}
