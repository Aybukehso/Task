using ErpaTask.Data;
using ErpaTask.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ErpaTask.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly AppDbContext _db;

		public UserController(AppDbContext db)
		{
			_db = db;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var users = await _db.Users.ToListAsync();
			return Ok(new { data = users });
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(User user)
		{
			if (user != null && ModelState.IsValid)
			{
				var usr = await _db.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);

				if (usr != null)
				{
					return Ok(new { message = "Success" });
				}
			}

			return BadRequest(new { message = "Invalid credentials" });
		}
	}
}
