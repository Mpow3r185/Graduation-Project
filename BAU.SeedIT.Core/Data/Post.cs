using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bau.Seedit.Core.Data
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int published { get; set; }
        public int authorId { get; set; }
        [ForeignKey("user_id")] 
        public virtual Account Account { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime publishedAt { get; set; }
        public string image { get; set; }
        public int upVote { get; set; }
        public int downVote { get; set; }

        public ICollection<Comment> comments { get; set; }
        public ICollection<PostAction> postActions { get; set; }



    }
}
