using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using NHibernate.Criterion;

namespace DataAccess.DAO
{
    public class BookDao : DaoBase<Book>
    {
        public BookDao() : base()
        {

        }

        public IList<Book> GetBookPage(int count, int page, out int totalBooks)
        {
            totalBooks = session.CreateCriteria<Book>()
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();

            return session.CreateCriteria<Book>()
                .AddOrder(Order.Desc("PosteDate"))
                .SetFirstResult((page - 1)*count)
                .SetMaxResults(count)
                .List<Book>();
        }

        public IList<Book> SearchBook(string phrase)
        {
            return session.CreateCriteria<Book>()
                .Add(Restrictions.Like("Title", String.Format("%{0}%", phrase)))
                .List<Book>();
        }

        public IList<Book> GetBookInCategoryId(int id)
        {
            return session.CreateCriteria<Book>()
                .CreateAlias("Category", "cat")
                .Add(Restrictions.Eq("cat.Id", id))
                .List<Book>();
        }

        public IList<Book> GetBookPagedByAuthorId(int count, int page, out int totalBooks, int id)
        {
            totalBooks = session.CreateCriteria<Book>()
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();

            return session.CreateCriteria<Book>()
                .CreateAlias("Author", "u")
                .Add(Restrictions.Eq("u.Id", id))
                .AddOrder(Order.Desc("PosteDate"))
                .SetFirstResult((page - 1)*count)
                .SetMaxResults(count)
                .List<Book>();
        }
    }
}
