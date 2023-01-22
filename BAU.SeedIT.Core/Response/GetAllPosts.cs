using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.Response
{
    public class GetAllPosts
    {
        public List<PostDTO> posts { get; set; }
        public PostActionDTO PostActions { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public AccountDTO author { get; set; }
        public Profile profile { get; set; }
    }
}
