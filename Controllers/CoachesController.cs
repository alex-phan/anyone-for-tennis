using AnyoneForTennis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnyoneForTennis.Controllers
{
    public class CoachesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CoachesController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var members = _userManager.GetUsersInRoleAsync("Coach").Result;

            return View(members);
        }
    }
}
