using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.Response
{
    public class ProfilePostRes
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public string ProfilePic { get; set; }
        public string ProfilePicThumbnail { get; set; }
        public string ProfileUserName { get; set; }
        public string Address { get; set; }
    }
}
