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

        // View all members.
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var members = _userManager.GetUsersInRoleAsync("Member").Result;

            return View(members);
        }

        // View member details.
        //public async Task<IActionResult> Details(int? id)
        //{
        //	if (id == null || _context.Schedule == null)
        //	{
        //		return NotFound();
        //	}

        //	var schedule = await _context.ApplicationUser;
        //		.FirstOrDefaultAsync(m => m.Id == id);
        //	if (schedule == null)
        //	{
        //		return NotFound();
        //	}

        //	return View(schedule);
        //}
    }
}
