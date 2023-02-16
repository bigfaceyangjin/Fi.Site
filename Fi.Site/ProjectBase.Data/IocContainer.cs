using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ProjectBase.Data.Dao
{
	public class IocContainer:IDisposable
	{
		public static UnityContainer container = new UnityContainer();
		public static T Resove<T>()
		{
			try
			{
				return container.Resolve<T>();
			}
			catch (Exception ex)
			{
				throw new ApplicationException(string.Format("不能取回{0}类型，请在 IocContainer.Instance.Container 中映射{0}类型", typeof(T)), ex);
			}
		}
		public void Dispose()
		{
			container.Dispose();
			container = null;
		}
	}
}
