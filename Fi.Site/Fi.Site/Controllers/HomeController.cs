using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fi.Site.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Top()
		{
			ViewBag.Message = "Your application description page.";
			ViewBag.Info = "Giving up is for rookies!";

			return View();
		}

		public ActionResult Left()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult Right()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult Bottom()
		{
			return View();
		}
		public ActionResult ErJi()
		{
			return View();
		}
		public ActionResult LeftTest()
		{
			return View();
		}
	}
}