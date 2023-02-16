using ProjectBase.Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Business.Filters
{
	public class ConsigneeFilter:ParameterFilter
	{
		/// <summary>
		/// 收货商名称
		/// </summary>
		public virtual string DeliveryName { get; set; }
		/// <summary>
		/// 公司名称
		/// </summary>
		public virtual string CompanyName { get; set; }
		/// <summary>
		/// 生产Hql查询语句
		/// </summary>
		/// <returns></returns>
		public override string ToHql()
		{
			string hql = "";
			if (!string.IsNullOrEmpty(DeliveryName))
			{
				hql += " and DeliveryName=:DeliveryName ";
			}
			if (!string.IsNullOrEmpty(CompanyName))
			{
				hql += " and CompanyName=:CompanyName ";
			}
			return hql;
		}
		/// <summary>
		/// 构造查询参数
		/// </summary>
		/// <returns></returns>
		public override Dictionary<string, object> GetParameters()
		{
			var result = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(DeliveryName))
			{
				result["DeliveryName"] = DeliveryName;
			}
			if (!string.IsNullOrEmpty(CompanyName))
			{
				result["CompanyName"] = CompanyName;
			}
			return result;
		}
	}
}
