using System;
namespace KatieSite.Models
{
    public class TTRPG
    {
        public string name { get; set; }
        public string publisher { get; set; }
        public  DateTime publishedDate { get; set; }
        public string genre { get; set; }
        public string focus { get; set; }
        public int easeOfAccess { get; set; }
        public int stars { get; set; }
        public string rating { get; set; }
        public string description { get; set; }
        public Review review { get; set; }

    }
}
