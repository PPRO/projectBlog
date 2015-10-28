using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using NHibernate.Criterion;

namespace DataAccess.DAO
{
    public class AuthorDao : DaoBase<Author>
    {
        public IList<Author> GetAuthor(string surname, string name)
        {
            return session.CreateCriteria<Author>()
                .CreateAlias("Name", "n")
                .CreateAlias("Surname", "s")
                .Add(Restrictions.Eq("n.Name", name))
                .Add(Restrictions.Eq("s.Surname", surname))
                .List<Author>();
        }
    }
}
