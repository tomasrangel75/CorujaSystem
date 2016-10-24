
using CorujaSystem.Migrations;
using CorujaSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _ctx;
		private Dictionary<Type, object> _repositories;
		private bool _disposed;
       

        public UnitOfWork()
		{
			_ctx = new ApplicationDbContext();
			_repositories = new Dictionary<Type, object>();
			_disposed = false;
        }

		public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
		{
			if (_repositories.Keys.Contains(typeof(TEntity)))
				return _repositories[typeof(TEntity)] as IRepository<TEntity>;

			var repository = new Repository<TEntity>(_ctx);
			_repositories.Add(typeof(TEntity), repository);
			return repository;
		}


        public int SetUpProfile(int action, string userId, string profile)
        {
            UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
            int result = 0;

            try
            {
                switch (action)
                {
                    case 1: //ADD

                        if (!_userManager.IsInRole(userId, profile))
                        {
                            _userManager.AddToRole(userId, profile);
                            result = 1;
                        }
                        break;         
                    case 2: //DEL
                        _userManager.RemoveFromRole(userId, profile);
                         result = 1;
                        break;

                    case 3: //CHECK
                        if (_userManager.IsInRole(userId, profile)) result = 1;
                        break;
                        
                            default:
                        break;
                }
                return result;

            }
            catch (Exception)
            {

                return -1;
            }

        }
       

        public void Save()
		{
			_ctx.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					_ctx.Dispose();
				}

				this._disposed = true;
			}
		}
	}
}
