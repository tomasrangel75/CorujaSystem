using CorujaPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaPresentation.DAL
{
	public class ApiService : IService
	{
		private Repository<ReportKey> _reportKeys;
		private Repository<UserMapKey> _userMapKeys;
		private Repository<ApplicationUser> _applicationUsers;

		private ApplicationDbContext _ctx;
		public ApiService()
		{
			_ctx = new ApplicationDbContext ();
		}

		public Repository<ReportKey> ReportKeys
		{
			get
			{
				if (_reportKeys == null)
				{
					//_reportKeys = new ApplicationDbContext(_ctx);
				}
				return _reportKeys;
			}

		}

		public Repository<UserMapKey> UserMapKeys
		{
			get
			{
				if (_userMapKeys == null)
				{
					//_userMapKeys = new CursosRepository(_ctx);
				}
				return _userMapKeys;
			}

		}

		public Repository<ApplicationUser> ApplicationUsers
		{
			get
			{
				if (_applicationUsers == null)
				{
					//_applicationUsers = new ProfessorsRepository(_ctx);
				}
				return _applicationUsers;
			}

		}


	}
}
