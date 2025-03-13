using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zitadel.Authentication;
namespace backend.src.Modules.Auth.Presentation.Controller
{  
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private class TokenResponse
        {
            [JsonPropertyName("access_token")]
            public string AccessToken { get; set; }

            [JsonPropertyName("id_token")]
            public string IdToken { get; set; }

            [JsonPropertyName("refresh_token")]
            public string RefreshToken { get; set; }

            [JsonPropertyName("token_type")]
            public string TokenType { get; set; }

            [JsonPropertyName("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonPropertyName("scope")]
            public string Scope { get; set; }

            [JsonPropertyName("sub")] // Subject identifier
            public string Sub { get; set; }
        }
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

[HttpGet("register")]
        public IActionResult GetRegisterUrl()
        {
            var clientId = _configuration["Authentication:ClientId"];
            var callbackUrl = Url.Action(nameof(Callback), "Auth", null, "http");
            var state = Guid.NewGuid().ToString("N");
            
            var registerUrl = $"{_configuration["Authentication:Authority"]}/oauth/v2/authorize?" +
                            $"client_id={clientId}&" +
                            "response_type=code&" +
                            "scope=openid%20profile%20email&" +
                            $"redirect_uri={Uri.EscapeDataString(callbackUrl)}&" +
                            $"state={state}&" +
                            "prompt=select_account";

            return Ok(new { url = registerUrl, state });
        }

        [HttpGet("login")]
        public IActionResult GetLoginUrl()
        {
            var clientId = _configuration["Authentication:ClientId"];
            var callbackUrl = Url.Action(nameof(Callback), "Auth", null, "http");
            var state = Guid.NewGuid().ToString("N");
            
            var loginUrl = $"{_configuration["Authentication:Authority"]}/oauth/v2/authorize?" +
                          $"client_id={clientId}&" +
                          "response_type=code&" +
                          "scope=openid%20profile%20email&" +
                          $"redirect_uri={Uri.EscapeDataString(callbackUrl)}&" +
                          $"state={state}";

            return Ok(new { url = loginUrl, state });
        }

        [HttpGet("callback")]
        public async Task<IActionResult> Callback([FromQuery] string code, [FromQuery] string state)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest("Authorization code is required");
            if (string.IsNullOrEmpty(state))
                return BadRequest("State parameter is required");

            try
            {
                var client = _httpClientFactory.CreateClient();
                var callbackUrl = Url.Action(nameof(Callback), "Auth", null, "http");

                var tokenRequest = new Dictionary<string, string>
                {
                    ["grant_type"] = "authorization_code",
                    ["code"] = code,
                    ["client_id"] = _configuration["Authentication:ClientId"],
                    ["client_secret"] = _configuration["Authentication:ClientSecret"],
                    ["redirect_uri"] = callbackUrl
                };

                var response = await client.PostAsync(
                    $"{_configuration["Authentication:Authority"]}/oauth/v2/token",
                    new FormUrlEncodedContent(tokenRequest)
                );

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { 
                        message = "Token exchange failed", 
                        statusCode = response.StatusCode, 
                        details = errorContent 
                    });
                }

                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(
                    await response.Content.ReadAsStringAsync()
                );

                // Decode the ID token to get user claims
                var jwtHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtHandler.ReadJwtToken(tokenResponse.IdToken);
                var claims = new List<Claim>();

                foreach (var claim in jwtToken.Claims)
                {
                    claims.Add(new Claim(claim.Type, claim.Value));
                }

                // Ensure basic claims are present
                if (!claims.Any(c => c.Type == ClaimTypes.NameIdentifier))
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, tokenResponse.Sub ?? "unknown"));
                if (!claims.Any(c => c.Type == ClaimTypes.Name) && jwtToken.Claims.Any(c => c.Type == "name"))
                    claims.Add(new Claim(ClaimTypes.Name, jwtToken.Claims.First(c => c.Type == "name").Value));
                if (!claims.Any(c => c.Type == ClaimTypes.Email) && jwtToken.Claims.Any(c => c.Type == "email"))
                    claims.Add(new Claim(ClaimTypes.Email, jwtToken.Claims.First(c => c.Type == "email").Value));

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        IssuedUtc = DateTimeOffset.UtcNow,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(tokenResponse.ExpiresIn)
                    }
                );

                return Ok(new
                {
                    message = "Successfully authenticated",
                    tokens = new
                    {
                        tokenResponse.AccessToken,
                        tokenResponse.IdToken,
                        tokenResponse.RefreshToken,
                        tokenResponse.ExpiresIn
                    },
                    receivedState = state
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Authentication error", details = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("profile")]

        public IActionResult Profile()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized(new { message = "Please authenticate first" });

            var userInfo = new
            {
                Name = User.FindFirst(ClaimTypes.Name)?.Value ?? "Not provided",
                Email = User.FindFirst(ClaimTypes.Email)?.Value ?? "Not provided",
                Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Not provided",
        
            };

            return Ok(userInfo);
        }
    }
}