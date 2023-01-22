using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.DTO;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.ServiceInterface
{
    public interface IAccountService
    {

        //Create
        string CreateAccount(Account account);

        List<Account> GetAllAccount();

        string UserLogin(UserLoginDTO userLoginDTO);

        bool UpdateAccount(Account account);
        bool DeleteAccount(int id);
        Profile getProfileById(int id);
        AccountDTO getUserById(int userid);
        AccountDTO getUserByEmail(string email);
        Profile getProfileByUserId(int userId);
        Account getUserByUserName(string userName);
        List<Profile> getAllProfiles();
        Profile CreateProfile(Profile profile);
        Profile UpdateProfile(Profile profile);
        string getMyName();
        string UploadImage(int id, string image);
        string UploadThumb(int id, string image);
    }
}
