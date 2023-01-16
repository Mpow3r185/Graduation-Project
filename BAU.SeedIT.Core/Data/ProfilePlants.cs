using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BAU.SeedIT.Core.Data
{
    public class ProfilePlants
    {
        [Key]
        public int id { get; set; }
        public int profileId { get; set; }
        public int plantId { get; set; }

    }
}
