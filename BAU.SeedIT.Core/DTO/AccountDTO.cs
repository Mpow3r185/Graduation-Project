using Bau.Seedit.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

     
    }
}
