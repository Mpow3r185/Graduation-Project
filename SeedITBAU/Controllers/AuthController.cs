using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.ServiceInterface;
using BAU.SeedIT.Core.Data;
using BAU.SeedIT.Core.DTO;
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
        Token token = new Token();
        Login login = new Login();
        private readonly IAccountService accountService;

        public AuthController(IAccountService _accountService)
        {
            accountService = _accountService;
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
                try
                {

                    var token = Request.Headers["x-auth-token"].ToString().Replace("Bearer ", "");
                    string jwt = token;
                    Console.WriteLine(token);
                    Console.WriteLine(jwt);
                    var handler = new JwtSecurityTokenHandler();
                    var token1 = handler.ReadJwtToken(jwt);
                    userId = token1.Claims.First(c => c.Type == "unique_name").Value;
                    AccountDTO account = accountService.getUserById(Int32.Parse(userId));
                    Profile profile = accountService.getProfileByUserId(Int32.Parse(userId));

                    // Extract the expiration date and time from the token
                    string exp = token1.Claims.First(c => c.Type == "exp").Value;
                    DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp)).UtcDateTime;
                    int comparison = DateTime.Compare(dateTime, DateTime.Now);
                    if (comparison <= 0)
                    {
                        var newTokenV = GenerateJWT();
                        login.token = newTokenV;
                        login.user = account;
                        if (profile == null)
                        {
                            return Ok(login);
                        }
                        return Ok(new LoginResp
                        {
                            Token = login.token,
                            User = new UserLoginRes
                            {
                                Id = account.Id,
                                Email = account.Email,
                                Name = account.Name,
                                CreatedAt = account.CreatedAt,
                                Profile = new ProfileLoginRes
                                {
                                    Id = profile.Id,
                                    Bio = profile.bio,
                                    ProfilePic = profile.profilePic,
                                    ProfilePicThumbnail = profile.profilePicThumbnail,
                                    ProfileUserName = profile.profileUserName,
                                    Address = profile.address,


                                }
                            }
                        });
                    }


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

                    return Unauthorized("Unauthorized");
                }
                catch (Exception)
                {
                    // token is invalid
                    return Unauthorized("Unauthorized");
                }
                }
                catch (Exception)
                {
                    return Unauthorized("Unauthorized");
                }

                // Generate a new token
                var newToken = GenerateJWT();
                AccountDTO account1 = accountService.getUserById(Int32.Parse(userId));
                Profile profile1 = accountService.getProfileByUserId(account1.Id);
                // Return the new token
                login.token = newToken;
                login.user = account1;
                if (profile1 == null)
                {
                    return Ok(login);
                }
                return Ok(new LoginResp
                {
                    Token = login.token,
                    User = new UserLoginRes
                    {
                        Id = account1.Id,
                        Email = account1.Email,
                        Name = account1.Name,
                        CreatedAt = account1.CreatedAt,
                        Profile = new ProfileLoginRes
                        {
                            Id = profile1.Id,
                            Bio = profile1.bio,
                            ProfilePic = profile1.profilePic,
                            ProfilePicThumbnail = profile1.profilePicThumbnail,
                            ProfileUserName = profile1.profileUserName,
                            Address = profile1.address,


                        }
                    }
                });
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
