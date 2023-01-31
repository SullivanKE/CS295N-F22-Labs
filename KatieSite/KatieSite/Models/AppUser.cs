using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KatieSite.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime SignUpDate { get; set; }

        [NotMapped] 
        public IList<string> RoleNames { get; set; } = null!;
    }
}
