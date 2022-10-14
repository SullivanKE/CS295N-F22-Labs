using System;
namespace KatieSite.Models
{
    public class Review
    {
        public string user { get; set; }
        public DateTime date { get; set; }
        public int rating { get; set; }
        public string text { get; set; }

    }
}
