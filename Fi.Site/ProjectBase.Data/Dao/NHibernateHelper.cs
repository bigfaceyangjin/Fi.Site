using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBase.Data.Dao
{
	public class NHibernateHelper
	{
		private static ISessionFactory sessionFactory = null;
		public static ISessionFactory SessionFactory {
			get {
				return sessionFactory == null ? (new Configuration()).Configure().BuildSessionFactory() : sessionFactory;
			}
		}
	}
}
