using DataAccess.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Dao;

namespace MafieBlog.Areas.Admin.Controllers
{
	[Authorize]
    public class RubrikaController : Controller
    {
        // GET: Admin/Rubrika
		
	    public ActionResult Index(int id)
	    {

		    IList<Article> articles = new ArticleDao().GetArticleInCategoryId(id);

		    return View("Rubrika", articles);
	    }
		
        public ActionResult Amerika()
        {
	        int id = 1;

	        IList<Article> articles = new ArticleDao().GetArticleInCategoryId(id);

            return View("Rubrika",articles);
        }

	    public ActionResult Cesko()
	    {

			int id = 2;

			IList<Article> articles = new ArticleDao().GetArticleInCategoryId( id );
		    return View("Rubrika", articles);
	    }
		
	    public ActionResult Italie()
	    {
			int id = 3;

			IList<Article> articles = new ArticleDao().GetArticleInCategoryId( id );
		    return View("Rubrika", articles);
	    }

	    public ActionResult Jakuza()
	    {
			int id = 4;

			IList<Article> articles = new ArticleDao().GetArticleInCategoryId( id );
		    return View("Rubrika", articles);
	    }

	    public ActionResult Rusko()
	    {
			int id = 5;

			IList<Article> articles = new ArticleDao().GetArticleInCategoryId( id );
		    return View("Rubrika", articles);
	    }

	    public ActionResult ArticleDetail(int id)
	    {
		    Article article = new ArticleDao().GetById(id);

		    return View(article);
	    }

		
	    
    }
}