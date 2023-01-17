using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAU.SeedIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
    
        static string userId;

        public AuthController()
        {
            
        }

        [HttpPost]
        [Route("refresh-token")]
        public IActionResult RefreshToken()
        {
            var token5 = Request.Headers["x-auth-token"].ToString();
            if (string.IsNullOrEmpty(token5))
            {
                return Unauthorized();
            }

            // Get the token from the request header
            if (Request.Headers.ContainsKey("x-auth-token"))
            {
                var token = Request.Headers["x-auth-token"].ToString().Replace("Bearer ", "");
                string jwt = token;
                Console.WriteLine(token);
                Console.WriteLine(jwt);
                var handler = new JwtSecurityTokenHandler();
                var token1 = handler.ReadJwtToken(jwt);
                userId = token1.Claims.First(c => c.Type == "unique_name").Value;

                // Validate the token
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING ,JWT SECRET KEY IN SIGNATURE")), //Jwt:Key
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                try
                {

                    tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                }
                catch (SecurityTokenException)
                {
                    var newTokenV = GenerateJWT();
                    return Ok(JsonConvert.SerializeObject(newTokenV));
                    // return Unauthorized("Token is expired");
                }
                catch (Exception)
                {
                    // token is invalid
                    return Unauthorized("Invalid token");
                }

                // Generate a new token
                var newToken = GenerateJWT();

                // Return the new token
                return Ok(JsonConvert.SerializeObject(newToken));
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateJWT()
        {
            // Generate and return a new JWT
            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenKey = Encoding.ASCII.GetBytes("SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING ,JWT SECRET KEY IN SIGNATURE");

            var TokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name,userId.ToString()) //(LoginResult.Id).ToString()


                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(TokenDes);
            return TokenHandler.WriteToken(token);
        }
    }
}
