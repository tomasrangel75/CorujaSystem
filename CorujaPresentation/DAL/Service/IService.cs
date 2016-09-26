
using CorujaPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaPresentation.DAL
{
	public interface IService
	{
		Repository<ReportKey> ReportKeys { get; }
		Repository<UserMapKey> UserMapKeys { get; }
		Repository<ApplicationUser> ApplicationUsers { get; }
	}
}
