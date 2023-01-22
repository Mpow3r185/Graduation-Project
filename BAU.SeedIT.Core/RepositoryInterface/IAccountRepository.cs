using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.DTO;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.RepositoryInterface
{
    public interface IAccountRepository
    {

        AccountDTO CreateAccount(Account account);
        List<Account> GetAllAccount();

        Account UserLogin(UserLoginDTO userLoginDTO);

        bool UpdateAccount(Account account);

        bool DeleteAccount(int id);

        AccountDTO getUserById(int userid);
        Account getUserByUserName(string userName);

        List<Profile> getAllProfiles();

        Profile CreateProfile(Profile profile);
        Profile getProfileById(int id);
        AccountDTO getUserByEmail(string email);
        Profile getProfileByUserId(int userId);

        Profile UpdateProfile(Profile profile);

        string UploadImage(int id, string image);
        string UploadThumb(int id, string image);




    }
}
