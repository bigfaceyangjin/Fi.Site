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
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="TID"></typeparam>
	/// <typeparam name="TDao"></typeparam>
	public abstract class DomainObject<T,TID,TDao> 
		where T:DomainObject<T,TID, TDao>
		where TDao : IDao<T,TID>
	{
		protected static TDao dao
		{
			get {
				return IocContainer.Resove<TDao>();
			}
		}

		public static T GetById(TID id)
		{
			return dao.GetById(id);
		}
		public static IList<T> GetAll()
		{
			return dao.GetAll();
		}
		public virtual void Delete()
		{
			dao.Delete((T)this);
		}
		public virtual void Save()
		{
			dao.Save((T)this);
		}
		public virtual void SaveOrUpdate()
		{
			dao.SaveOrUpdate((T)this);
		}
	}
}
