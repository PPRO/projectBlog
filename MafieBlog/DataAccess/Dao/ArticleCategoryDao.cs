using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;

namespace DataAccess.Dao
{
    public class ArticleCategoryDao : DaoBase<ArticleCategory>
    {
        public ArticleCategoryDao() : base()
        {
            
        }
		// Vraci seznam kategorii
	    public IList<ArticleCategory> GetArticleCategories(string name)
	    {
		    return  session.CreateCriteria<ArticleCategory>()
					.CreateAlias("Name", "n")
					.Add(Restrictions.Eq("n.Name", name))
					.List<ArticleCategory>();
	    } 
    }
}
