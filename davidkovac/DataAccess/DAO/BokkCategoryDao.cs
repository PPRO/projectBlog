using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using NHibernate.Criterion;

namespace DataAccess.DAO
{
    public class BookCategoryDao : DaoBase<BookCategory>
    {
        public IList<BookCategory> GetArticleCategories(string category)
        {
            return session.CreateCriteria<BookCategory>()
                .CreateAlias("Name", "n")
                .Add(Restrictions.Eq("n.Name", category))
                .List<BookCategory>();
        }
    }
}
