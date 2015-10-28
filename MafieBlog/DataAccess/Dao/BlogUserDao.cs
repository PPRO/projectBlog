using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DataAccess.Dao
{
	public class BlogUserDao : DaoBase<BlogUser>
	{
		public BlogUser GetByLoginAndPassword(string login, string password)
		{
			
			return session.CreateCriteria<BlogUser>()
					.Add(Restrictions.Eq("Login", login))
					.Add(Restrictions.Eq("Password", password))
					.UniqueResult<BlogUser>();
		}
		
		public BlogUser GetByLogin(string login)
		{
			return session.CreateCriteria<BlogUser>()
				.Add(Restrictions.Eq("Login", login))
				.UniqueResult<BlogUser>();
		}



	}
}
