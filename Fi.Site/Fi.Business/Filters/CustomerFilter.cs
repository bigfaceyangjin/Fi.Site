using ProjectBase.Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Business.Filters
{
	public class CustomerFilter : ParameterFilter
	{
		/// <summary>
		/// 客户代码
		/// </summary>
		public virtual string Cus_Code { get; set; }
		/// <summary>
		/// 客户姓名
		/// </summary>
		public virtual string Cus_Name { get; set; }
		public override string ToHql()
		{
			string hql = "";
			if (!string.IsNullOrEmpty(Cus_Code))
			{
				hql += " and Cus_Code=:Cus_Code ";
			}
			if (!string.IsNullOrEmpty(Cus_Name))
			{
				hql += " and Cus_Name=:Cus_Name ";
			}
			return hql;
		}
		public override Dictionary<string, object> GetParameters()
		{
			var rs = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(Cus_Code))
			{
				rs["Cus_Code"] = Cus_Code.Trim();
			}
			if (!string.IsNullOrEmpty(Cus_Name))
			{
				rs["Cus_Name"] = Cus_Name.Trim();
			}
			return rs;
		}
	}
}
