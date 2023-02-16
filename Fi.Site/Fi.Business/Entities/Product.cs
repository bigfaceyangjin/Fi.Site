using Fi.Business.Repositories;
using Fi.Common.Page;
using ProjectBase.Data.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Business.Entities
{
	public class Product: DomainObject<Product, int, IProductRepository>
	{	
		public virtual int ID { get; set; }
		[Display(Name = "商品名称")]
		[Required(ErrorMessage = "商品名称是必填项！")]
		public virtual string ProductName { get; set; }
		[Display(Name = "商品价格")]
		[Required(ErrorMessage = "商品价格是必填项！")]
		public virtual int Price { get; set; }

		public static IPageOfList<Product> GetByFilter(ParameterFilter filter)
		{
			return dao.GetByFilter(filter);
		}
	}
}
