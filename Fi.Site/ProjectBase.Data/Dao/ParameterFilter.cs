using Fi.Common.ExtensionMethods;
using System.Collections.Generic;

namespace ProjectBase.Data.Dao
{
	/// <summary>
	/// 自定义查询条件
	/// </summary>
	public abstract class ParameterFilter
	{
		public ParameterFilter()
		{
			HasQueryString = false;
		}
		/// <summary>
		/// 若为fase，ToHql()则只需返回条件查询" code from Table a where 1=1"
		/// 若为true，ToHql()则需返回连from在内的完整hql语句
		/// </summary>
		public bool HasQueryString { get; set; }
		public string OrderBy { get; set; }
		public abstract string ToHql();
		public override string ToString()
		{
			return this.ToHql();
		}
		public abstract Dictionary<string, object> GetParameters();
		public string GetOrderString()
		{
			if (OrderBy.HasValue())
			{
				return " Order by " + this.OrderBy;
			}
			return string.Empty;
		}
		public string GetLike(string value)
		{
			return "%"+value+"%";
		}
		public int pageIndex { get; set; }
		public int pageSize { get; set; }
	}
}
