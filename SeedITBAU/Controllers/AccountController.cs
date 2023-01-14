using Bau.Seedit.Core.Common;
using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.DTO;
using Bau.Seedit.Core.ServiceInterface;
using BAU.SeedIT.Core.Data;
using BAU.SeedIT.Core.DTO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bau.Seedit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IDbContext dbContext;
        //private static readonly Cloudinary Cloudinary = new Cloudinary(
        //    new CloudinaryDotNet.Account("dwb7swvaf", "832363197752178", "eiHmj9s3_MG6VfQGBp0rQN02LmM"));
        Token token = new Token();
        Login login = new Login();
        public AccountController(IAccountService _accountService, IDbContext _dbContext)
        {
            accountService = _accountService;
            dbContext = _dbContext;
        }
        [HttpGet]
        public List<Core.Data.Account> GetAllAccount()
        {
            return accountService.GetAllAccount();
        }
        [HttpGet]
        [Route("GetAccountById/{userid}")]
        public Core.Data.Account GetUserById(int userid)
        {
            return accountService.getUserById(userid);
        }

        [HttpPost]
        public IActionResult CreateAccount(Core.Data.Account account)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                account.Id = Guid.NewGuid().GetHashCode();

                Core.Data.Account account1 = accountService.getUserById(account.Id);

                token.token = accountService.CreateAccount(account);
                token.user = new AccountDTO { Id = account1.Id, Email = account1.Email, Name = account1.Name };

                if(token.token == null)
                {
                    return BadRequest("The Email or Name is already exist");
                }

                return Ok(token);
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                return BadRequest("A account with that email already exists.");
            }

        }
        [HttpGet]
        [Route("getAllProfiles")]
        public List<Profile> getAllProfiles()
        {
            return accountService.getAllProfiles();
        }
    
        [HttpPost]
        [Route("createProfile")]
        public IActionResult createProfile(Profile profile)
        {
     
            profile.Id = Guid.NewGuid().GetHashCode();
             accountService.CreateProfile(profile);
            Profile profile1 = accountService.getProfileById(profile.Id);
            //token.profile = new Profile { Id = profile.Id, bio = profile.bio, profilePic = profile.profilePic, profilePicThumbnail = profile.profilePicThumbnail, profileUserName = profile.profileUserName, address = profile.address, UserId = profile.UserId}

            return Ok(profile1);
            
        }
        [HttpPut]
        public bool UpdateAccount(Core.Data.Account account)
        {
            return accountService.UpdateAccount(account);
        }
        [HttpPut]
        [Route("updateProfile")]
        public IActionResult UpdateProfile(Profile profile)
        {
            try
            {
                accountService.UpdateProfile(profile);
                Profile profile1 = accountService.getProfileById(profile.Id);

                return Ok(profile1);
            }
            catch(Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("deleteAccount/{id}")]//
        public bool DeleteAccount(int id)
        {
            return accountService.DeleteAccount(id);
        }
        [HttpGet, Authorize]
        [Route("Auth")]
        public ActionResult<string> GetMe()
        {
            var userName = accountService.getMyName();
            return Ok(userName);
        }


        [HttpPost]
        [Route("login")]
        public IActionResult UserLogin(UserLoginDTO userLoginDTO)
        {
            AccountDTO account = accountService.getUserByEmail(userLoginDTO.Email);
            login.token = accountService.UserLogin(userLoginDTO);
            login.user = account;
            Profile profile = accountService.getProfileByUserId(account.Id);

            if (login.token != null)
            {
                //return Ok(login);
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
            else
            {
                return Unauthorized("Username or Password is incorrect");
            }
        }
        //[HttpPost]
        //[Route("AutoLogin")]
        //public IActionResult AutoLogin(UserLoginDTO userLoginDTO)
        //{

        //}

        [HttpPut]
        [Route("Upload/{id}")]
        public async Task<IActionResult> UploadImageAsync(int id, IFormFile image)
        {
            Profile profile = accountService.getProfileById(id);
            try
            {
                var cloudinary = new Cloudinary(new CloudinaryDotNet.Account(
                        "dotbqgdma",
                      "129178149167614",
                      "MVIwDYZkH6Ra7PX-VIINQDUY50s"
                ));
                var result = await cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                    Transformation = new Transformation().Width(300).Height(300)
                });

                var result2 = await cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                    Transformation = new Transformation().Width(150).Height(150).Crop("thumb")
                });


                Console.WriteLine(id);
                Console.WriteLine(result.Uri.ToString());
                accountService.UploadThumb(id, result2.Uri.ToString());
                accountService.UploadImage(id, result.Uri.ToString());
               // return CreatedAtAction(nameof(UploadImageAsync), new { id = profile.Id }, profile);
                return Ok(profile);

            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }



    }
}
