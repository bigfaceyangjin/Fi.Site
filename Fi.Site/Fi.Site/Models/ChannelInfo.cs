using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fi.Site.Models
{
	/// <summary>
	/// 渠道信息
	/// </summary>
	public class ChannelInfo
	{
		/// <summary>
		/// 渠道Id
		/// </summary>
		public virtual int Id { get; set; }
		/// <summary>
		/// 渠道风格
		/// </summary>
		public virtual string ChannelStyle { get; set; }
		/// <summary>
		/// 渠道编码
		/// </summary>
		public virtual string ChannelCode { get; set; }
		/// <summary>
		/// 中文名称
		/// </summary>
		public virtual string CnName { get; set; }
		/// <summary>
		/// 英文名称
		/// </summary>
		public virtual string EnName { get; set; }
		/// <summary>
		/// 状态
		/// </summary>
		public virtual string Status { get; set; }
	}
}