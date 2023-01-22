using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Bau.Seedit.Core.Common;
using Bau.Seedit.Core.DTO;
using System.Security.Cryptography;
using BAU.SeedIT.Core.DTO;
using MySql.Data.MySqlClient;


namespace Bau.Seedit.Infra.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbContext dbContext;

        public AccountRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Account UserLogin(UserLoginDTO userLoginDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@emailAddress", userLoginDTO.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@userpassword", CreatePasswordHash(userLoginDTO.Password), dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Account> result = dbContext.Connection.Query<Account>("userLogin", parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
       //

        public AccountDTO CreateAccount(Account account)
        {
            try
            {
                AccountDTO accountDTO = new AccountDTO();
                accountDTO.Id = account.Id;
                accountDTO.Email = account.Email;
                accountDTO.Name = account.Name;
                var parameters = new DynamicParameters();
                parameters.Add("@user_id", account.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add("@userEmail", account.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add("@fullName", account.Name, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add("@userPassword", CreatePasswordHash(account.Password), dbType: DbType.String, direction: ParameterDirection.Input);
                dbContext.Connection.Query<AccountDTO>("createUser", parameters, commandType: CommandType.StoredProcedure);
                return accountDTO;
            }
            catch (MySqlException ex)
            {
                return null;
            }
                       

 

        }
        public Profile CreateProfile(Profile profile)
        {
            
            var parameters = new DynamicParameters();
            parameters.Add("@profile_id", profile.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@userBio", profile.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@userName", profile.profileUserName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@address_", profile.address, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@user_id", profile.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@profilePicture", profile.profilePic, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@profilePictureThumbnail", profile.profilePicThumbnail, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Profile> result = dbContext.Connection.Query<Profile>("createProfile", parameters, commandType: CommandType.StoredProcedure);
            return profile;
        }
        public Profile getProfileById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("profile_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return dbContext.Connection.Query<Profile>("getProfileById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public AccountDTO getUserByEmail(string email)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("emailAddress", email, dbType: DbType.String, direction: ParameterDirection.Input);

            return dbContext.Connection.Query<AccountDTO>("getUserByEmail", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public Profile getProfileByUserId(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return dbContext.Connection.Query<Profile>("getProfileByUserId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public List<Profile> getAllProfiles()
        {
            IEnumerable<Profile> result = dbContext.Connection.Query<Profile>("getAllProfiles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        static string CreatePasswordHash(string pass)
        {
            if(pass == null)
                 return "";
            var algo = MD5.Create();
            var asByte = Encoding.UTF8.GetBytes(pass);
            var hashedPass = algo.ComputeHash(asByte);
            return Convert.ToBase64String(hashedPass);

        }

        public bool UpdateAccount(Account account)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_id", account.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@userEmail", account.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@fullName", account.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("updateUser", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public Profile UpdateProfile(Profile profile)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@profile_id", profile.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@userBio", profile.bio, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@userName", profile.profileUserName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@address_", profile.address, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("updateProfile", parameters, commandType: CommandType.StoredProcedure);
            return profile;
        }

        public bool DeleteAccount(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("deleteUser", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<Account> GetAllAccount()
        {
            IEnumerable<Account> result = dbContext.Connection.Query<Account>("getAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public AccountDTO getUserById(int userid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("user_id",  userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return dbContext.Connection.Query<AccountDTO>("getUserById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public Account getUserByUserName(string userName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("user_name", userName, dbType: DbType.String, direction: ParameterDirection.Input);

            return dbContext.Connection.Query<Account>("getAccountByUsername", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public string UploadImage(int id, string image)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@profilePicture", image, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@user_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Profile> result = dbContext.Connection.Query<Profile>("uploadImage", parameters, commandType: CommandType.StoredProcedure);
            return result.ToString();
        }
        public string UploadThumb(int id, string image)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@picture", image, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@profile_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Profile> result = dbContext.Connection.Query<Profile>("uploadThumbnail", parameters, commandType: CommandType.StoredProcedure);
            return result.ToString();
        }



    }
}
