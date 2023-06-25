using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaTask.Model
{
	public class Account:BaseModel
	{
        public decimal  Amount { get; set; }

		// Hesap bir kullanıcıya ait olmalı
		public int UserId { get; set; }
		public User User { get; set; }

		// Hesap bir bankaya ait olmalı
		public int BankId { get; set; }
		public Bank Bank { get; set; }
	}
}
