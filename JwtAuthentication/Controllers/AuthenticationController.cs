using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JwtAuthentication.Services;

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Test()
        {
            return Ok("Connection to secure resource successful.");
        }

        [HttpPost]
        public ActionResult RequestToken([FromBody] AuthenticationRequest request)
        {
           

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthenticationResponse authenticationResponse;
            if(_authenticationService.IsAuthenticated(request, out authenticationResponse))
            {
                return Ok(authenticationResponse);
            }

            return BadRequest("Invalid Request");

        }



    }
}