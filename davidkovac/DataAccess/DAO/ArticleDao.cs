using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using NHibernate.Criterion;

namespace DataAccess.DAO
{
    public class ArticleDao : DaoBase<Article>
    {
        public ArticleDao() : base()
        {

        }

        public IList<Article> GetArticlePage(int count, int page, out int totalBooks)
        {
            totalBooks = session.CreateCriteria<Article>()
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();

            return session.CreateCriteria<Article>()
                .AddOrder(Order.Desc("PosteDate"))
                .SetFirstResult((page - 1)*count)
                .SetMaxResults(count)
                .List<Article>();
        }

        public IList<Article> SearchArticle(string phrase)
        {
            return session.CreateCriteria<Article>()
                .Add(Restrictions.Like("Title", String.Format("%{0}%", phrase)))
                .List<Article>();
        }

        public IList<Article> GetArticleInCategoryId(int id)
        {
            return session.CreateCriteria<Article>()
                .CreateAlias("Category", "cat")
                .Add(Restrictions.Eq("cat.Id", id))
                .List<Article>();
        }

        public IList<Article> GetArticlePagedByUserId(int count, int page, out int totalBooks, int id)
        {
            totalBooks = session.CreateCriteria<Article>()
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();

            return session.CreateCriteria<Article>()
                .CreateAlias("User", "u")
                .Add(Restrictions.Eq("u.Id", id))
                .AddOrder(Order.Desc("PosteDate"))
                .SetFirstResult((page - 1)*count)
                .SetMaxResults(count)
                .List<Article>();
        }
    }
}
