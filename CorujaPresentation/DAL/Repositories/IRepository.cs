using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CorujaPresentation.DAL
{
	public interface IRepository<T> where T : class
	{

		//Unit of work///////////
		void Add(T entity);
		void Delete(T entity);
		void DeleteById(int Id);
		void Update(T entity);
		//////////////////////////

		T AddEntity(T entity);
		int DeleteEntity(T entity);
		int DeleteEntityById(int Id);
		T UpdateEntity(T entity);
		
		T GetById(int Id);
		IEnumerable<T> All();
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

		void save(); //(for Service layer)
	}
}
