using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MafieBlog.IModel;
using MafieBlog.Models;


namespace MafieBlog.Controllers
{
	
	public class HomeController : Controller
	{
	    readonly Tlacitko tlacitko;

	    
		public ActionResult Index( int? page)
		{

			int itemsOnPage = 10;
			int pg = page ?? 1;
			int totalArticles;
			
			
			ArticleDao articleDao = new ArticleDao();
			IList<Article> articles = articleDao.GetArticlePaged( itemsOnPage, pg, out totalArticles);
			/*
			IList<BlogComment> comments = new BlogCommentDao().GetAll();
		*/
			ViewBag.Pages = (int)Math.Ceiling( (double)totalArticles / (double)itemsOnPage );
			ViewBag.CurrentPage = pg;
			ViewBag.Category = new ArticleCategoryDao().GetAll();
			
			return View(articles);
		}

		
		public ViewResult Zajimavosti(TlacitkoModel model)
		{

		    model.IsCheck = false;

			return View(model);
		}

        
	    public ViewResult Tlac(TlacitkoModel model)
	    {

            bool m = model.IsCheck;

            TlacitkoModel mo = new TlacitkoModel();
            mo.IsCheck = model.IsCheck;

            if (m)
                TempData["ano"] = "ano";
            else
                TempData["ano"] = "ne";

	        return View(mo);
	    }

		public ActionResult Kontakt()
		{
			return View();
		}

}
}