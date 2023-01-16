using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bau.Seedit.Core.Data
{
    public class PostAction
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        [ForeignKey("user_id")]
        public virtual Account Account { get; set; }
        public int postId { get; set; }
        [ForeignKey("id")]
        public virtual Post Post { get; set; }
        public int commentId { get; set; }
        [ForeignKey("id")]
        public virtual Comment Comment { get; set; }
        public bool upVote { get; set; }
        public bool downVote { get; set; }

    }
}
