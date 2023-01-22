using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.DTO
{
    public class PostDTO
    {
        public List<GetPostData> posts { get; set; }
        public AccountDTO author { get; set; }
        public Profile Profile { get; set; }
        
    }
}
