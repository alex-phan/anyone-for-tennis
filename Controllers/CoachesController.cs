using AnyoneForTennis.Data;
using AnyoneForTennis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnyoneForTennis.Controllers
{
	[Authorize]
    public class CoachesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
		private readonly ApplicationDbContext _context;

		public CoachesController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
			_context = context;
        }

		// View all coaches.
		[Authorize(Roles = "Admin, Member")]
		public IActionResult Index()
        {
            var members = _userManager.GetUsersInRoleAsync("Coach").Result;

            return View(members);
        }

		// View coach details.
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
