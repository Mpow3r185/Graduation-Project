using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bau.Seedit.Core.Data
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        

        public ICollection<Profile> profiles{ get; set; }
        public ICollection<Post> posts{ get; set; }
        public ICollection<PostAction> postActions { get; set; }
    }
}
