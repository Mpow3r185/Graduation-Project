using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.Data
{
    public class LoginResp
    {
        public string Token { get; set; }
        public UserLoginRes User { get; set; }
    }
}
