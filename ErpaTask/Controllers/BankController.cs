using ErpaTask.Data;
using ErpaTask.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpaTask.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BankController : ControllerBase
	{
		private readonly AppDbContext _db;

		public BankController(AppDbContext db)
		{
			_db = db;
		}

		// GET: api/Bank
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var banks = await _db.Banks.ToListAsync();
			return Ok(new { data = banks });
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Bank bank)
		{
			try
			{
				if (bank == null)
				{
					return BadRequest("Geçersiz banka verileri.");
				}

				_db.Banks.Add(bank);
				await _db.SaveChangesAsync();

				return CreatedAtRoute("GetBank", new { id = bank.Id }, bank);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(Guid id)
		{
			var bank = await _db.Banks.FindAsync(id);
			if (bank == null)
			{
				return NotFound();
			}

			_db.Banks.Remove(bank);
			await _db.SaveChangesAsync();

			return Ok();
		}

	}
}
