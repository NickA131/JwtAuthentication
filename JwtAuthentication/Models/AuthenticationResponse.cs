using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Models
{
    public class AuthenticationResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
