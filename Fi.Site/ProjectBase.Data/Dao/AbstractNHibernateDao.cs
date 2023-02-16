using Fi.Common.Page;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBase.Data.Dao
{
	/// <summary>
	/// 数据持久化基类
	/// </summary>
	public abstract class AbstractNHibernateDao<T,TId>:IDao<T,TId>
	{
		/// <summary>
		/// NHibernate操作数据库的session
		/// </summary>
		protected ISession NhibernateSession {
			get {
				return NHibernateHelper.SessionFactory.OpenSession();
			}
		}
		Type persitent = typeof(T);
		public T GetById(TId id)
		{
			return GetById(id, false);
		}
		public T GetById(TId id, bool shouldLock)
		{
			if (shouldLock)
			{
				return NhibernateSession.Get<T>(id, LockMode.Upgrade);
			}
			else {
				return NhibernateSession.Get<T>(id);
			}
		}
		public IList<T> GetAll()
		{
			//var list= NhibernateSession.Query<Customers>().ToList();
			Type t= typeof(T);
			return NhibernateSession.Query<T>().ToList();
		}
		public IList<T> GetCriters(params ICriterion[] criterias)
		{
			ICriteria criteria = NhibernateSession.CreateCriteria(persitent);
			foreach (ICriterion item in criterias)
			{
				criteria.Add(item);
			}
			criteria.AddOrder(new Order("ID", false));
			return criteria.List<T>();
		}
		public IPageOfList<T> GetByT(T t, int pageIndex, int pageSize, params string[] propertyInclude)
		{
			ICriteria criteria = NhibernateSession.CreateCriteria(persitent);
			Example example= Example.Create(t);
			foreach (string item in propertyInclude)
			{
				example.ExcludeProperty(item);
			}
			example.ExcludeNone();
			example.ExcludeNulls();
			example.ExcludeZeroes();
			int recordTotal = Convert.ToInt32((criteria.Clone() as ICriteria).SetProjection(Projections.Count("ID")).UniqueResult());
			criteria.AddOrder(new Order("ID",false));
			criteria.Add(example).SetFirstResult(pageIndex*pageSize).SetMaxResults(pageSize);
			return new PageOfList<T>(criteria.List<T>(), pageIndex, pageSize, recordTotal);
		}
		public T GetByUniqueT(T t, params string[] propertyInclude)
		{
			ICriteria criteria = NhibernateSession.CreateCriteria(t.GetType());
			Example exam = Example.Create(t);
			foreach (string prop in propertyInclude)
			{
				exam.ExcludeProperty(prop);
			}
			exam.ExcludeNone();
			exam.ExcludeNulls();
			exam.ExcludeZeroes();
			criteria.Add(exam);
			criteria.AddOrder(new Order("ID", false));
			IList<T> list = criteria.List<T>();
			if (list.Count > 1)
			{
				throw new NonUniqueResultException(list.Count);
			}
			if (list.Count > 0)
			{
				return list[0];
			}
			else {
				return default(T);
			}
		}

		public T Save(T t)
		{
			NhibernateSession.Save(t);
			NhibernateSession.Flush();
			return t;
		}
		public T SaveOrUpdate(T t)
		{
			NhibernateSession.SaveOrUpdate(t);
			NhibernateSession.Flush();
			return t;
		}
		public void Delete(T t)
		{
			NhibernateSession.Delete(t);
			NhibernateSession.Flush();
		}
		public void CommitChanges()
		{
			
		}
		public IPageOfList<T> GetByFilter(ParameterFilter filter)
		{
			string sql = $" from {typeof(T).Name} a where 1=1 ";
			if (filter.HasQueryString)
			{
				sql = filter.ToHql();
			}
			else {
				sql += filter.ToHql();
			}
			var paras = filter.GetParameters();
			var countQuery =NhibernateSession.CreateQuery("select count(*) " + sql);
			var query = NhibernateSession.CreateQuery("select a " + sql + filter.GetOrderString());

			foreach (var key in paras.Keys)
			{
				countQuery.SetParameter(key, paras[key]);
				query.SetParameter(key, paras[key]);
			}

			int pageIndex = filter.pageIndex;
			int pageSize = filter.pageSize;
			long recodTotal = Convert.ToInt64(countQuery.UniqueResult());
			var list = query.SetFirstResult(pageIndex * pageSize).SetMaxResults(pageSize).List<T>();
			return new PageOfList<T>(list, pageIndex, pageSize, recodTotal);
		}
	}
}
