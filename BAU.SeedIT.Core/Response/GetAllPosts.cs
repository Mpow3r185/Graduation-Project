using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.Response
{
    public class GetAllPosts
    {
        public List<Post> posts { get; set; }
        public List<PostActionDTO> PostActions { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public List<AccountDTO> Author { get; set; }
    }
}
