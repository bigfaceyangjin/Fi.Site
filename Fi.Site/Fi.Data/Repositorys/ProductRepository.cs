using Fi.Business.Entities;
using Fi.Business.Repositories;
using ProjectBase.Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi.Data.Repositorys
{
	public class ProductRepository: AbstractNHibernateDao<Product,int>, IProductRepository
	{

	}
}
