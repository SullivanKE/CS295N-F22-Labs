using System;
using System.ComponentModel.DataAnnotations;

namespace KatieSite.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }

        public int rating { get; set; }
        public string url { get; set; }

    }
}
