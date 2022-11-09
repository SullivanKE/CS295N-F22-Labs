using System;
using System.ComponentModel.DataAnnotations;

namespace KatieSite.Models
{
    public class ForumPost
    {
        [Key]
        public int PostId { get; set; }
        public string user { get; set; }
        public DateTime date { get; set; }
        public string head { get; set; }
        public string body { get; set; }
        public Rating rating { get; set; }

    }
}
