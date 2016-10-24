using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.DAL
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DbContext _context;
		private readonly IDbSet<T> _dbset;

		public Repository(DbContext context)
		{
			_context = context;
			_dbset = context.Set<T>();
		}

		//UnitOfWork of Work ////////////////// 
		public virtual void Add(T entity)
		{
			_dbset.Add(entity);

        }
	
		public virtual void Delete(T entity)
		{
			var entry = _context.Entry(entity);
			entry.State = EntityState.Deleted;
		}
		
		public virtual void DeleteById(int Id)
		{
			var entityToDelete = _dbset.Find(Id);
			DeleteEntity(entityToDelete);
		}

		public virtual void Update(T entity)
		{
			var entry = _context.Entry(entity);
			_dbset.Attach(entity);
			entry.State = EntityState.Modified;
		}

		////////////////////////////////////////
		
		public virtual T AddEntity(T entity)
		{
			_dbset.Add(entity);
			_context.SaveChanges();
			return entity;
		}

		public virtual int  DeleteEntity(T entity)
		{
			int result;
			var entry = _context.Entry(entity);
			entry.State = EntityState.Deleted;
			result = _context.SaveChanges();
			return result;
		}
		public virtual int DeleteEntityById(int Id)
		{
			int result;
			var entityToDelete = _dbset.Find(Id);
			DeleteEntity(entityToDelete);
			result = _context.SaveChanges();
			return result;
		}

		public virtual T UpdateEntity(T entity)
		{
			var entry = _context.Entry(entity);
			_dbset.Attach(entity);
			entry.State = EntityState.Modified;
			_context.SaveChanges();
			return entity;
		}

		public virtual T GetById(int id)
		{
			return _dbset.Find(id);
		}

		public virtual IEnumerable<T> All()
		{
			return _dbset;
		}

		public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return _dbset.Where(predicate);
		}

		public void save()
		{
			_context.SaveChanges();
		}

          
    }
}
