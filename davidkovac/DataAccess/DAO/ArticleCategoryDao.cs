using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using NHibernate.Criterion;

namespace DataAccess.DAO
{
    public class ArticleCategoryDao : DaoBase<ArticleCategory>
    {
        public IList<ArticleCategory> GetArticleCategories(string category)
        {
            return session.CreateCriteria<ArticleCategory>()
                .CreateAlias("Name", "n")
                .Add(Restrictions.Eq("n.Name", category))
                .List<ArticleCategory>();
        }
    }
}
