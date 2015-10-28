using DataAccess.Interface;
using DataAccess.Model;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace DataAccess.Dao
{
    public class DaoBase<T> : IDaoBase<T> where T: class , IEntity
    {

        protected ISession session;

        protected DaoBase()
        {
            session = NHibernateHelper.Session;
        }
		// vraci vesechny zaznamy
        public IList<T> GetAll()
        {
            return session.QueryOver<T>().List<T>();
        }

		// vraci vsechny clanky
		public IList<Article> GetAllArticle()
		{
			return session.QueryOver<Article>().List<Article>();
		} 

		// vraci sezan kategorii clanku (rubrika)
	    public IList<ArticleCategory> GetArticleCategories()
	    {
		    return session.QueryOver<ArticleCategory>().List<ArticleCategory>();
	    }

	    // vytvori zaznam
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
		// upravi zaznam
        public void Update(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction ())
            {
                session.Update(entity);
                transaction.Commit();
            }
        }
		// smaze zaznam 
        public void Delete(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction ())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }
			 
        public T GetById(int id)
        {
            return session.CreateCriteria<T>().Add(Restrictions.Eq("Id", id)).UniqueResult<T>();
        }

		
		
    }
}
