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
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }
        public Rating Rating { get; set; }

        // public virtual ICollection<ForumPost> Posts { get; set; }
    }
}
