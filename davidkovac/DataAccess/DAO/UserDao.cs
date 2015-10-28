using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using NHibernate;
using NHibernate.Criterion;

namespace DataAccess.DAO
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDao : DaoBase<User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetByLoginAndPasswordUser(string login, string password)
        {
            return session.CreateCriteria<User>()
                .Add(Restrictions.Eq("Login", login))
                .Add(Restrictions.Eq("Password", password))
                .UniqueResult<User>();
        }

        public User GetByLogin(string nick)
        {
            return session.CreateCriteria<User>().
                Add(Restrictions.Eq("Login", nick)).
                UniqueResult<User>();
        }

    }
}
