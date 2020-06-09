using JwtAuthentication.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication.Services
{
    public class JwtAuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly AuthenticationManagement _authenticationManagement;

        public JwtAuthenticationService(IUserService userService, IOptions<AuthenticationManagement> authenticationManagement)
        {
            _userService = userService;
            _authenticationManagement = authenticationManagement.Value;
        }

        public bool IsAuthenticated(AuthenticationRequest request, out AuthenticationResponse authenticationResponse)
        {

            authenticationResponse = new AuthenticationResponse();
            var user = _userService.Authenticate(request.UserName, request.Password);
            if (user == null)
                return false;

            var claim = new[]
            {
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires =  DateTime.Now.AddMinutes(_authenticationManagement.AccessExpiration),
                SigningCredentials = credentials
            };

            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
            authenticationResponse.Token = tokenHandler.WriteToken(jwtToken);

            return true; 
        }
    }
}
