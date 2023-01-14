using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.Data
{
    public class Login
    {
        public string token { get; set; }
        public AccountDTO user { get; set; }
        public Profile profile { get; set; }
    }
}
