using ErpaTask.Data;
using ErpaTask.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ErpaTask.Controllers
{
	public class AccountController : Controller
	{
		private readonly AppDbContext _db;

		public AccountController(AppDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost("LoadMoney")]
		public IActionResult LoadMoney(string accountId, decimal amount, string bankName, string iban)
		{
			// Hesap kimliğini Guid'e dönüştür
			if (!Guid.TryParse(accountId, out Guid accountGuid))
			{
				return BadRequest("Invalid account ID.");
			}

			// Hesabı veritabanından al
			Account account = _db.Accounts.FirstOrDefault(a => a.Id == accountGuid);
			if (account == null)
			{
				return NotFound("Account not found.");
			}

			// Bankayı veritabanından al
			Bank bank = _db.Banks.FirstOrDefault(b => b.Name == bankName && b.Iban == iban);
			if (bank == null)
			{
				return NotFound("Bank not found.");
			}

			// Hesaba para yükle
			account.Amount += amount;

			// İlgili bankayı bağla
			account.Bank = bank;

			// Veritabanını güncelle
			_db.SaveChanges();

			return Ok("Money loaded successfully.");
		}

		//Para Çekme
		[HttpPost("WithdrawMoney")]
		public IActionResult WithdrawMoney(string accountId, decimal amount, string bankName, string iban)
		{
			// Hesap kimliğini Guid'e dönüştür
			if (!Guid.TryParse(accountId, out Guid accountGuid))
			{
				return BadRequest("Invalid account ID.");
			}

			// Hesabı veritabanından al
			Account account = _db.Accounts.FirstOrDefault(a => a.Id == accountGuid);
			if (account == null)
			{
				return NotFound("Account not found.");
			}

			// Bankayı veritabanından al
			Bank bank = _db.Banks.FirstOrDefault(b => b.Name == bankName && b.Iban == iban);
			if (bank == null)
			{
				return NotFound("Bank not found.");
			}

			// Hesaptan para çek
			if (account.Amount < amount)
			{
				return BadRequest("Insufficient funds.");
			}
			account.Amount -= amount;

			// İlgili bankayı bağla
			account.Bank = bank;

			// Veritabanını güncelle
			_db.SaveChanges();

			return Ok("Money withdrawn successfully.");
		}
		//Para İste

		[HttpPost("RequestMoney")]
		public IActionResult RequestMoney(string accountId, decimal amount, string bankName, string iban)
		{
			// Hesap kimliğini Guid'e dönüştür
			if (!Guid.TryParse(accountId, out Guid accountGuid))
			{
				return BadRequest("Invalid account ID.");
			}

			// Hesabı veritabanından al
			Account account = _db.Accounts.FirstOrDefault(a => a.Id == accountGuid);
			if (account == null)
			{
				return NotFound("Account not found.");
			}

			// Bankayı veritabanından al
			Bank bank = _db.Banks.FirstOrDefault(b => b.Name == bankName && b.Iban == iban);
			if (bank == null)
			{
				return NotFound("Bank not found.");
			}

			// İlgili bankayı bağla
			account.Bank = bank;

			// Veritabanını güncelle
			_db.SaveChanges();

			// Para iste işlemiyle ilgili diğer işlemleri gerçekleştir (ör. e-posta bildirimi, loglama vb.)

			return Ok("Money request sent successfully.");
		}




	}
}
