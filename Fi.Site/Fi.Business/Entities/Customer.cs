using Fi.Business.Filters;
using Fi.Business.Repositories;
using Fi.Common.Page;
using ProjectBase.Data.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Business.Entities
{
	public class Customer: DomainObject<Customer,int,ICustomerRepository>
	{
		#region Property
		/// <summary>
		/// 主键ID
		/// </summary>
		public virtual int ID { get; set; }
		/// <summary>
		/// 客户代码
		/// </summary>
		[Display(Name ="客户代码")]
		[Required(ErrorMessage ="客户代码不能为空")]
		[StringLength(30,MinimumLength =0,ErrorMessage ="客户代码长度不能超过30个字符")]
		public virtual string Cus_Code { get; set; }
		/// <summary>
		/// 客户名称
		/// </summary>
		[Display(Name ="客户名称")]
		[Required(ErrorMessage ="客户名称不能为空")]
		[StringLength(30,MinimumLength =0,ErrorMessage ="客户名称长度不能超过30个字符")]
		public virtual string Cus_Name { get; set; }
		/// <summary>
		/// 手机号
		/// </summary>
		[Display(Name ="手机号码")]
		public virtual string Phone { get; set; }
		/// <summary>
		/// 电话
		/// </summary>
		[Display(Name ="电话")]
		public virtual string Tel { get; set; }
		/// <summary>
		/// 邮箱
		/// </summary>
		[Display(Name ="邮箱")]
		[RegularExpression(@"^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$", ErrorMessage ="邮箱格式不正确")]
		public virtual string Email { get; set; }
		/// <summary>
		/// 传值
		/// </summary>
		[Display(Name ="传值")]
		public virtual string Fax { get; set; }
		/// <summary>
		/// 国家
		/// </summary>
		[Display(Name = "国家")]
		public virtual string Country { get; set; }
		/// <summary>
		/// 地址
		/// </summary>
		[Display(Name = "地址")]
		public virtual string Address { get; set; }
		/// <summary>
		/// 公司名称
		/// </summary>
		[Display(Name = "公司名称")]
		public virtual string CompanyName { get; set; }
		[Display(Name = "金额")]
		public virtual decimal Balance { get; set; }
		[Display(Name = "信用额度")]
		public virtual decimal CreditAmount { get; set; }
		[Display(Name = "状态")]
		public virtual CustomerStatus Status { get; set; }
		[Display(Name ="客户业务类型")]
		public virtual BusssinessType BusssinessType { get; set; }
		[Display(Name ="快件收货信息")]
		public virtual IList<Consignee> consigneeBy { get; set; }
		#endregion
		#region common method
		public static IPageOfList<Customer> GetByFilter(CustomerFilter filter)
		{
			return dao.GetByFilter(filter);
		}
		#endregion
	}
	/// <summary>
	/// 客户状态
	/// </summary>
	public enum CustomerStatus {
		[Description("启用")]
		Enable =0,
		[Description("禁用")]
		Disabled=1
	}
	/// <summary>
	/// 客户业务类型
	/// </summary>
	public enum BusssinessType {
		[Description("快件")]
		ExpressDelivery =0
	}
}
