using Fi.Common.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBase.Data.Dao
{
	/// <summary>
	/// 提供对数据基本增删改查的接口
	/// </summary>
	public interface IDao<T,TID>
	{
		/// <summary>
		/// 根据Id获取T类型实例对象
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		T GetById(TID id);
		/// <summary>
		/// 返回T类型所有实例
		/// </summary>
		/// <returns></returns>
		IList<T> GetAll();
		/// <summary>
		/// 返回分页后与T值相同的对象列表
		/// </summary>
		/// <param name="t"></param>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="propertyInclude">要排除的查询条件属性名</param>
		/// <returns></returns>
		IPageOfList<T> GetByT(T t, int pageIndex, int pageSize, params string[] propertyInclude);
		/// <summary>
		/// 返回与T值相同的唯一对象
		/// </summary>
		/// <param name="t"></param>
		/// <param name="propertyInclude">要排除的查询条件属性名</param>
		/// <returns></returns>
		T GetByUniqueT(T t, params string[] propertyInclude);
		/// <summary>
		/// 将指定的对象保存到数据库
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		T Save(T t);
		/// <summary>
		/// 将对象保存或更新到数据库
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		T SaveOrUpdate(T t);
		/// <summary>
		/// 从数据库中删除此对象
		/// </summary>
		/// <param name="t"></param>
		void Delete(T t);
		/// <summary>
		/// 根据查询条件查询结果
		/// </summary>
		/// <param name="filter">查询条件</param>
		/// <returns></returns>
		IPageOfList<T> GetByFilter(ParameterFilter filter);
		//立即提交到数据库
		void CommitChanges();
	}
}
