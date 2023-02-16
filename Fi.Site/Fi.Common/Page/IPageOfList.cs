using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Common.Page
{
	public interface IPageOfList
	{
		/// <summary>
		/// 页索引
		/// </summary>
		int PageIndex { get; set; }
		/// <summary>
		/// 页容量
		/// </summary>
		int PageSize { get; set; }
		/// <summary>
		/// 总页数
		/// </summary>
		int PageCount { get; }
		/// <summary>
		/// 总记录条数
		/// </summary>
		long TotalCount { get; set; }
	}
	public interface IPageOfList<T> : IPageOfList, IList<T>
	{

	}
}
