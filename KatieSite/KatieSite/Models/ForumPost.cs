using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KatieSite.Models
{
    public class ForumPost
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PostId { get; set; }
        public AppUser User { get; set; }

        public DateTime Date { get; set; }
		[Required(ErrorMessage = "Post head is required")]
		public string Head { get; set; }
		[Required(ErrorMessage = "Post body is required")]
		public string Body { get; set; }
		[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
		public int Rating { get; set; }
        public RpgBook Book { get; set; }
        public IEnumerable<ForumPost> Reply { get; set; } = new List<ForumPost>();

        // public virtual ICollection<ForumPost> Posts { get; set; }
    }
}
