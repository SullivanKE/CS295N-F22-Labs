using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KatieSite.Models
{
    public class ForumPost
    {
        [Key]
        public int PostId { get; set; }
        public AppUser User { get; set; }
        public DateTime Date { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public string Url { get; set; }

        // public virtual ICollection<ForumPost> Posts { get; set; }
    }
}
