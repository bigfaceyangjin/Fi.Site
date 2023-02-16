using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Common.Page
{
	public class PageOfList<T>:List<T>,IList<T>,IPageOfList,IPageOfList<T>
	{
		public PageOfList(IEnumerable<T> items,int pageIndex,int pageSize,long totalCount)
		{
			this.PageSize = PageSize;
			this.PageIndex = PageIndex;
			this.TotalCount = totalCount;
		}
		public PageOfList(int pageSize)
		{
			if (PageSize <= 0)
			{
				throw new ArgumentException("pageSize must gart 0!","pageSize");
			}
		}
		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public long TotalCount { get; set; }
		public int PageCount { get {
				return (int)TotalCount / PageSize+(TotalCount%PageSize>0?1:0);
			} }
		public int CurrentStart {
			get {
				return PageIndex * PageSize + 1;
			}
		}
		public int CurrentEnd {
			get {
				return (PageIndex + 1) * PageSize > TotalCount ? (int)TotalCount : (PageIndex+1)*PageSize;
			}
		}
	}
}
