using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaTask.Model
{
	public class BaseModel
	{

		public Guid Id { get; set; } = new Guid () ;
	
		public string? Name { get; set; }	
		public bool IsDeleted { get; set; }	= false;	
		public bool isAdmin { get; set; }=false;	

	}
}
