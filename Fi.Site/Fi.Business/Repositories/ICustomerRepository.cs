using Fi.Business.Entities;
using ProjectBase.Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Business.Repositories
{
	public interface ICustomerRepository:IDao<Customer,int>
	{
	}
}
