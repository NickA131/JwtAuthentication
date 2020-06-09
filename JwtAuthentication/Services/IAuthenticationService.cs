using JwtAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Services
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated(AuthenticationRequest request, out AuthenticationResponse response);
    }
}
