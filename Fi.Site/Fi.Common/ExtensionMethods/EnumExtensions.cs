using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Common.ExtensionMethods
{
	public static class EnumExtensions
	{
		/// <summary>
		/// 获取Description特性值
		/// </summary>
		/// <param name="obj">枚举变量值或属性值</param>
		/// <param name="isTop">是否获取枚举头的值或类字段的值</param>
		/// <returns></returns>
		public static string GetDescription(this object obj,bool isTop)
		{
			if (obj == null)
			{
				return string.Empty;
			}
			try
			{
				Type enumType = obj.GetType() ;
				DescriptionAttribute attri = null;
				if (isTop)
				{
					attri = (DescriptionAttribute)Attribute.GetCustomAttribute(enumType, typeof(DescriptionAttribute));
				}
				else {
					FieldInfo field = enumType.GetField(obj.ToString());
					attri = (DescriptionAttribute)Attribute.GetCustomAttribute(field,typeof(DescriptionAttribute));
				}
				if (attri != null&&!string.IsNullOrEmpty(attri.Description))
				{
					return attri.Description;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return obj.ToString();
		}
	}
}
