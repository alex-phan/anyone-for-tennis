using AnyoneForTennis.Data;
using AnyoneForTennis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnyoneForTennis.Controllers
{
    public class CoachesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
		private readonly ApplicationDbContext _context;

		public CoachesController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
			_context = context;
        }

		// GET: Coaches
		public IActionResult Index()
        {
            var members = _userManager.GetUsersInRoleAsync("Coach").Result;

            return View(members);
        }

		// GET: Coach Details
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
