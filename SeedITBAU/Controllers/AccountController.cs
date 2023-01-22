using Bau.Seedit.Core.Common;
using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.DTO;
using Bau.Seedit.Core.ServiceInterface;
using BAU.SeedIT.Core.Data;
using BAU.SeedIT.Core.DTO;
using BAU.SeedIT.Core.ServiceInterface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IProfilePlantsService profilePlantsService;
        Token token = new Token();
        Login login = new Login();
        public AccountController(IAccountService _accountService, IProfilePlantsService _profilePlantsService)
        {
            accountService = _accountService;
            profilePlantsService = _profilePlantsService;
        }
        [HttpGet]
        public List<Core.Data.Account> GetAllAccount()
        {
            return accountService.GetAllAccount();
        }
        [HttpGet]
        [Route("GetAccountById/{userid}")]
        public AccountDTO GetUserById(int userid)
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
            
                account.Id = Math.Abs(Guid.NewGuid().GetHashCode());
                token.token = accountService.CreateAccount(account);
                AccountDTO account1 = accountService.getUserById(account.Id);
                
                token.user = new AccountDTO { Id = account1.Id, Email = account1.Email, Name = account1.Name };

            if (token.token == null)
            {
                return BadRequest("The Email or Name is already exist");
            }
            else
            {
                return Ok(token);
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

            try
            {
                profile.Id = Math.Abs(Guid.NewGuid().GetHashCode());
                accountService.CreateProfile(profile);
                Profile profile1 = accountService.getProfileById(profile.Id);
              
                return Ok(profile1);
            }
            catch (Exception)
            {
                return BadRequest();
            }

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
        [Route("deleteAccount/{id}")]
        public bool DeleteAccount(int id)
        {
            return accountService.DeleteAccount(id);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult UserLogin(UserLoginDTO userLoginDTO)
        {
            AccountDTO account = accountService.getUserByEmail(userLoginDTO.Email);
            if(account == null)
            {
                return Unauthorized("Username or Password is incorrect");
            }
            login.token = accountService.UserLogin(userLoginDTO);
            login.user = account;
            Profile profile = accountService.getProfileByUserId(account.Id);
            if(profile == null)
            {
                return Ok(login);
            }

            if (login.token != null)
            {
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

        [HttpPut]
        [Route("Upload/{id}")]
        public async Task<IActionResult> UploadImageAsync(int id, IFormFile image)
        {
            
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
                    Transformation = new Transformation().Width(400).Height(600)
                });

                var result2 = await cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                    Transformation = new Transformation().Width(75).Height(150).Crop("thumb")
                });


                Console.WriteLine(id);
                Console.WriteLine(result.Uri.ToString());
                accountService.UploadThumb(id, result2.Uri.ToString());
                accountService.UploadImage(id, result.Uri.ToString());
                Profile profile = accountService.getProfileById(id);
                return Ok(profile);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("getProfileById/{id}")]
        public IActionResult getProfileById(int id)
        {
            ProfilePlantsDTO profilePlantsDTO = new ProfilePlantsDTO();
            profilePlantsDTO.Profile = accountService.getProfileById(id);
            profilePlantsDTO.Plant = profilePlantsService.getPlantsByProfileId(id);
            return Ok(profilePlantsDTO);
        }
    }
}
