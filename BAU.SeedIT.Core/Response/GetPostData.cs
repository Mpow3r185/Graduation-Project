using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.Response
{
    public class GetPostData
    {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Image { get; set; }
            public DateTime CreatedAt { get; set; }
            public int UpVote { get; set; }
            public int DownVote { get; set; }
            public AccountProfileDTO Author { get; set; }
        

    }
}
