using Fi.Business.Entities;
using Fi.Business.Filters;
using Fi.Common.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Fi.Site.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public JsonResult List(CustomerFilter filter)
		{
			var dataSource= Customer.GetByFilter(filter);
			List<Customer> list= dataSource.ToList();
			var data = list.Select(c => new {
				ID = c.ID,
				Cus_Code = c.Cus_Code,
				Cus_Name = c.Cus_Name,
				Phone = c.Phone,
				Tel = c.Tel,
				Balance = c.Balance,
				CreditAmount = c.CreditAmount,
				Country = c.Country,
				CompanyName = c.CompanyName,
				BusssinessType = c.BusssinessType.GetDescription(false),
				Delivery = GetAllConsignees(c.consigneeBy),
				Status = c.Status.GetDescription(false)
			});
			//构造json格式传递
			var result = new { iTotalRecords=list.Count,iTotalDisplayRecords=10,data=data};
			return Json(result, JsonRequestBehavior.AllowGet);
		}
		/// <summary>
		/// 获取所有收货商名称
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public string GetAllConsignees(IList<Consignee> list)
		{
			StringBuilder sb = new StringBuilder();
			if (list != null && list.Count > 0)
			{
				foreach (Consignee c in list)
				{
					if (sb.Length > 0)
						sb.Append(", ");
					sb.Append(c.DeliveryName);
				}
			}
			return sb.ToString();
		}
    }
}