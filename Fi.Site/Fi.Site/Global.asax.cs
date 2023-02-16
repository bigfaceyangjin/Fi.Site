using Microsoft.Practices.Unity.Configuration;
using ProjectBase.Data.Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace Fi.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			RegisterContainer(IocContainer.container);

		}
		public void RegisterContainer(UnityContainer container)
		{
			//检索配置文件unity节点
			UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
			//将指定的容器配置应用于container
			section.Configure(container, "FirstContainer");
			var iReposi= Assembly.Load("Fi.Business").GetTypes().Where(t => t.FullName.Contains("Repositories")).ToList();
			var Reposi = Assembly.Load("Fi.Data").GetTypes().Where(t=>t.FullName.Contains("Repositorys")).ToList();
			iReposi.ForEach(t => {
				var real= t.Name.Substring(1, t.Name.Length - 1);
				var realT= Reposi.Where(r => r.Name == real).FirstOrDefault();
				if (realT != null)
				{
					container.RegisterType(t, realT);
				}
			});
		}
    }
}
