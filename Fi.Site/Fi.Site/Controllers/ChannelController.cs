using Fi.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fi.Site.Controllers
{
	public class ChannelController : Controller
	{
		// GET: Channel
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult AddChannel()
		{
			ViewBag.Title = "添加渠道";
			return View();
		}
		#region 假数据
		/// <summary>
		/// 渠道列表
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult List(ChannelInfo filter)
		{
			IEnumerable<ChannelInfo> list = this.GetChannelInfo();
			if (!string.IsNullOrWhiteSpace(filter.ChannelCode))
			{
				list = list.Where(x => x.ChannelCode == filter.ChannelCode.Trim());
			}
			if (!string.IsNullOrWhiteSpace(filter.CnName))
			{
				list = list.Where(x => x.CnName == filter.CnName.Trim());
			}
			if (!string.IsNullOrWhiteSpace(filter.EnName))
			{
				list = list.Where(x => x.CnName == filter.EnName.Trim());
			}
			var result = new { data = list.ToList(), totalCount = list.Count(), pageCount = 10 };
			return Json(result, JsonRequestBehavior.AllowGet);
		}
		/// <summary>
		/// 渠道列表数据
		/// </summary>
		/// <returns></returns>
		public List<ChannelInfo> GetChannelInfo()
		{
			List<ChannelInfo> list = new List<ChannelInfo>();
			try
			{
				for (int i = 0; i < 1100; i++)
				{
					list.Add(new ChannelInfo()
					{
						Id = i + 1,
						ChannelStyle = "香港E特快" + i,
						ChannelCode = "E_express" + i,
						CnName = "香港E特快" + i,
						EnName = "HK E-Express" + i,
						Status = "1"
					});
				}
				return list;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion
	}
}