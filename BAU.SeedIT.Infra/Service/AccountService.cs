using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.DTO;
using Bau.Seedit.Core.RepositoryInterface;
using Bau.Seedit.Core.ServiceInterface;
using BAU.SeedIT.Core.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Bau.Seedit.Infra.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }

        public string CreateAccount(Account account)
        {
            var RegisterResult = accountRepository.CreateAccount(account);

            if (RegisterResult != null)
            {
                var TokenHandler = new JwtSecurityTokenHandler();
                var TokenKey = Encoding.ASCII.GetBytes("SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING ,JWT SECRET KEY IN SIGNATURE");

                var TokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,(RegisterResult.Id).ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = TokenHandler.CreateToken(TokenDes);
                return TokenHandler.WriteToken(token);
            }
            else
            {
                return "Email or password incorrect!";
            }
        }
        public bool UpdateAccount(Account account)
        {
            return accountRepository.UpdateAccount(account);
        }
        public Profile UpdateProfile(Profile profile)
        {
            return accountRepository.UpdateProfile(profile);
        }

        public bool DeleteAccount(int id)
        {
            return accountRepository.DeleteAccount(id);
        }

        public List<Account> GetAllAccount()
        {
            return accountRepository.GetAllAccount();
        }
        public AccountDTO getUserByEmail(string email)
        {
            return accountRepository.getUserByEmail(email);
        }
         
        public List<Profile> getAllProfiles()
        {
            return accountRepository.getAllProfiles();
        }
        public Profile CreateProfile(Profile profile)
        {
            return accountRepository.CreateProfile(profile);
        }
        public Profile getProfileById(int id)
        {
            return accountRepository.getProfileById(id);
        }
        public AccountDTO getUserById(int userid)
        {
            return accountRepository.getUserById(userid);
        }
        public Account getUserByUserName(string userName)
        {
            return accountRepository.getUserByUserName(userName);
        }

        public string UserLogin(UserLoginDTO userLoginDTO)
        {
            var LoginResult = accountRepository.UserLogin(userLoginDTO);

            if (LoginResult != null)
            {
                var TokenHandler = new JwtSecurityTokenHandler();
                var TokenKey = Encoding.ASCII.GetBytes("SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING ,JWT SECRET KEY IN SIGNATURE");

                var TokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,(LoginResult.Id).ToString())
                        
                        
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = TokenHandler.CreateToken(TokenDes);
                return TokenHandler.WriteToken(token);
            }
            else
            {
                return null;
            }
        }
        public string UploadImage(int id, string image)
        {
            return accountRepository.UploadImage(id, image);
        }
        public string UploadThumb(int id, string image)
        {
            return accountRepository.UploadThumb(id, image);
        }

        public string getMyName()
        {
            throw new NotImplementedException();
        }

        public Profile getProfileByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
