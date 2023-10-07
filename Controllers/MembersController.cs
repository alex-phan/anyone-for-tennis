using AnyoneForTennis.Data;
using AnyoneForTennis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnyoneForTennis.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MembersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MembersController(UserManager<ApplicationUser> userManager)
        { 
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var members = _userManager.GetUsersInRoleAsync("Member").Result;

            return View(members);
        }
    }
}
