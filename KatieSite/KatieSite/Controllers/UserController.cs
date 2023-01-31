using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KatieSite.Models;

namespace KatieSite.Controllers
{
    [Authorize(Role = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private UserManager<AppUser> userManager; private RoleManager<IdentityRole> roleManager;
        public UserController(UserManager<AppUser> userMngr, RoleManager<IdentityRole> roleMngr)
        {
            userManager = userMngr; roleManager = roleMngr;
        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> users = new List<AppUser>(); 
            
            foreach (AppUser user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user); 
                users.Add(user);
            }
            UserViewModel model = new UserViewModel
            {
                Users = users,
                Roles = roleManager.Roles
            };

            return View(model);
        } // the other action methods } 
    }
}