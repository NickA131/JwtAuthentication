using JwtAuthentication.Entities;
using JwtAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Services
{
    public class UserService : IUserService
    {
        public User Authenticate(string username, string password)
        {
            var user = Users.GetAll().SingleOrDefault(x => x.UserName == username && x.Password == password);

            return user;
        }
    }
}
