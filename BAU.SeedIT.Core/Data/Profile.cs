using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bau.Seedit.Core.Data
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string bio { get; set; }
        public string profilePic { get; set; }
        public string profilePicThumbnail { get; set; }
        public string profileUserName { get; set; }
        public string address { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("user_id")]

        public virtual Account Account { get; set; }
    }
}
