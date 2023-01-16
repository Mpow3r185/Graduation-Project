using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.DTO
{
    public class ProfilePlantsDTO
    {
        public Profile Profile { get; set; }
        public List<Plants> Plant { get; set; }
    }
}
