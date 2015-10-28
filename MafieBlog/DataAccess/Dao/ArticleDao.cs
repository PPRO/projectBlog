using DataAccess.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class ArticleDao : DaoBase<Article>
    {
        public ArticleDao() : base()
        {
            
        }

	    public IList<Article> GetArticlePaged(int count, int page, out int totalBooks)
	    {
		    totalBooks = session.CreateCriteria<Article>()
				.SetProjection(Projections.RowCount())
				.UniqueResult<int>();

				// seradi podle name
		    return session.CreateCriteria<Article>()
				.AddOrder(Order.Desc("PostDate"))
			    .SetFirstResult((page - 1)*count)
			    .SetMaxResults(count)
			    .List<Article>();
	    }
		// vyhledavani ve clanku na zaklade shody phrase v Nazvu clanku
	    public IList<Article> SearchArticle(string phrase)
	    {
		    return session.CreateCriteria<Article>()
			    .Add(Restrictions.Like("Title", string.Format("%{0}%", phrase)))
			    .List<Article>();
	    }

		// vraci list se clanky v urcite kategorii
	    public IList<Article> GetArticleInCategoryId(int id)
	    {
		    return session.CreateCriteria<Article>()
			    .CreateAlias("Category", "cat")
			    .Add(Restrictions.Eq("cat.Id", id))
			    .List<Article>();
	    }

		
		// vraci seznam clanku na zaklade autora
		public IList<Article> GetArticlePagedByUserId( int count, int page, out int totalBooks, int id)
		{
			totalBooks = session.CreateCriteria<Article>()
				.SetProjection( Projections.RowCount() )
				.UniqueResult<int>();

			// seradi podle name
			return session.CreateCriteria<Article>()
				.CreateAlias( "User", "u" )
				.Add( Restrictions.Eq( "u.Id", id ) )
				.AddOrder( Order.Desc( "PostDate" ) )
				.SetFirstResult( ( page - 1 ) * count )
				.SetMaxResults( count )
				.List<Article>();
		}
    }
}
