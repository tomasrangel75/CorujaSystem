﻿
using CorujaPresentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaPresentation.DAL
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
