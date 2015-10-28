using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;

namespace DataAccess.Dao
{
	public class BlogCommentDao : DaoBase<BlogComment>
	{
		public BlogCommentDao() : base()
		{
			
		}

		public IList<BlogComment> GetCommentByArticleId(  out int totalComment, int id )
		{
			totalComment = session.CreateCriteria<BlogComment>()
				.CreateAlias("Article", "article")
				.Add(Restrictions.Eq("article.Id", id))
				.SetProjection( Projections.RowCount() )
				.UniqueResult<int>();

			// seradi podle name
			return session.CreateCriteria<BlogComment>()
				.CreateAlias("Article", "article")
				.Add( Restrictions.Eq( "article.Id", id ) )
				.AddOrder( Order.Desc( "CommentDate" ) )
				.List<BlogComment>();
		}
	}
}
