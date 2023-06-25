using ErpaTask.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaTask.Data
{
	public class AppDbContext:DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{


		}
		public virtual DbSet<User>Users { get; set; }	
		public virtual DbSet<Bank> Banks { get; set; }
		public virtual DbSet<Account> Accounts { get; set; }	


	}
}
