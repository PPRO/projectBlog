using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Interface;
using DataAccess.Model;
using NHibernate;
using NHibernate.Criterion;

namespace DataAccess.DAO
{
    public class DaoBase<T> : IDaoBase<T> where T : class , IEntity
    {

        protected ISession session;
        
        protected DaoBase()
        {
            session = NHibernateHelper.Session;
        }

        
        public IList<T> GetAll()
        {
            return session.QueryOver<T>().List<T>();
        }

        public object Create(T entity)
        {
            object o;
            using (ITransaction transaction = session.BeginTransaction())
            {
                o = session.Save(entity);
                transaction.Commit();
            }
            return o;
        }

        public void Update(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
            }
            
        }

        public void Delete(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }

        public T GetById(int id)
        {
            return session.CreateCriteria<T>().Add(Restrictions.Eq("Id", id)).UniqueResult<T>();
        }

        public IList<Article> GetAllArticle(out int totalArticle)
        {
            totalArticle = session.CreateCriteria<Article>().
                SetProjection(Projections.RowCount()).
                UniqueResult<int>();

            return session.QueryOver<Article>().List<Article>();
        }

        public IList<Book> GetAllBook(out  int totalBook)
        {
            totalBook = session.CreateCriteria<Book>()
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();

            return session.QueryOver<Book>().List<Book>();
        }

        public IList<ArticleCategory> GetArticleCategories(out int totalCategory)
        {
            totalCategory = session.CreateCriteria<ArticleCategory>()
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();

            return session.QueryOver<ArticleCategory>().List<ArticleCategory>();
        }

        public IList<BookCategory> GetBookCategories(out int totalGener)
        {
            totalGener = session.CreateCriteria<BookCategory>()
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();

            return session.QueryOver<BookCategory>().List<BookCategory>();
        }
    }
}
