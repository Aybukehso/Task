using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaTask.Model
{
	public class Bank:BaseModel
	{
        public string? Iban { get; set; }
		
		public string? Img { get; set; }
		public ICollection<Account>? Accounts { get; set; }
	}
}
