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
		public Guid UserId { get; set; }
		public virtual User? User { get; set; }

		// Hesap bir bankaya ait olmalı
		public Guid BankId { get; set; }
		public virtual Bank? Bank { get; set; }
	}
}
