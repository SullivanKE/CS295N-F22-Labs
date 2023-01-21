using System;
using System.ComponentModel.DataAnnotations;

namespace KatieSite.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int PostRating { get; set; }
        public string Url { get; set; }

    }
}
