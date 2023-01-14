using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.Data
{
    public class Token
    {
        public string token { get; set; }
        //public string password { get; set; }
        public AccountDTO user { get; set; }

    }
}
