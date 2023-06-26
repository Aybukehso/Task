using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaTask.Model
{
	public class User : BaseModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string? LastName { get; set; }
		public ICollection<Account>? Accounts { get; set; }
	}
}
