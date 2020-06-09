using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthentication.Models;

namespace JwtAuthentication.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
