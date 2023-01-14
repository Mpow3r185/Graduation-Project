using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bau.Seedit.Core.Data
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public int postId { get; set; }
        [ForeignKey("id")]
        public virtual Post Post { get; set; }
        public string text { get; set; }
        public int upVote { get; set; }
        public int downVote { get; set; }

        public ICollection<PostAction> postActions { get; set; }

    }
}
