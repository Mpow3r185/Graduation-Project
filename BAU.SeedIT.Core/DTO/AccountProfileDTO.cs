using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.DTO
{
    public class AccountProfileDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public ProfilePostRes Profile { get; set; }
    }
}
