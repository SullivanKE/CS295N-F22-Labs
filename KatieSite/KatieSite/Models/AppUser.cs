using Microsoft.AspNetCore.Identity;
using System;

namespace KatieSite.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime SignUpDate { get; set; }
    }
}
