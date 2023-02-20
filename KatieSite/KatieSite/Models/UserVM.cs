using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace KatieSite.Models
{
    public class UserVM
    {
        public IEnumerable<AppUser> Users { get; set; } = null!; 
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;

    }
}
