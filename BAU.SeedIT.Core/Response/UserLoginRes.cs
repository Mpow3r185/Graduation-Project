using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.Data
{
    public class UserLoginRes
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProfileLoginRes Profile { get; set; }
    }
}
