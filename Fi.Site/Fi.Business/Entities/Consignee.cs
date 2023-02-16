using Fi.Business.Filters;
using Fi.Business.Repositories;
using Fi.Common.Page;
using ProjectBase.Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Business.Entities
{
	public class Consignee:DomainObject<Consignee,int,IConsigneeRepository>
	{
		#region Property
		/// <summary>
		/// 主键ID
		/// </summary>
		public virtual int ID { get; set; }
		/// <summary>
		/// 客户ID
		/// </summary>
		public virtual int CusID { get; set; }
		/// <summary>
		/// 收货商ID
		/// </summary>
		public virtual int DeliveryID { get; set; }
		/// <summary>
		/// 收货商名称
		/// </summary>
		public virtual string DeliveryName { get; set; }
		/// <summary>
		/// 账户名称
		/// </summary>
		public virtual string AccountName { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>
		public virtual DateTime CreateTime { get; set; }
		/// <summary>
		/// 收货商
		/// </summary>
		public virtual Customer customerBy { get; set; }
		/// <summary>
		/// 是否匹配 true:已匹配	false：未匹配
		/// </summary>
		public virtual bool IsMatch { get; set; }
		#endregion
		#region Common Method
		public static IPageOfList<Consignee> GetFilter(CustomerFilter filter)
		{
			return dao.GetByFilter(filter);
		 }
		#endregion
	}
}
