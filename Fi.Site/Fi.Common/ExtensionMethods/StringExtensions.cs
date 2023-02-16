using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Common.ExtensionMethods
{
	public static class StringExtensions
	{
		/// <summary>
		/// 判断不为null或空字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool HasValue(this string value)
		{
			return !string.IsNullOrEmpty(value);
		}
	}
}
