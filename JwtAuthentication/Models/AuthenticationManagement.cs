using Newtonsoft.Json;

namespace JwtAuthentication.Models
{
    [JsonObject("authenticationManagement")]
    public class AuthenticationManagement
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("accessExpiration")]
        public int AccessExpiration { get; set; }

    }
}
