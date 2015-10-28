using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Helper;

namespace WebApplication4.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;
            return View();

        }

        public ActionResult AboutMe()
        {
            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;
            return View();
        }

       public ActionResult Contact()
        {
            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;
            return View();
        }

       /// <summary>
       /// Nové články
       /// </summary>
       /// <returns>První 3 články na úvodní stránku</returns>
       [ChildActionOnly]
       public ActionResult ArticleNew()
       {
           int itemOnPage = 3;
           int pg = 1;
           int totalArticle;

           IList<Article> articles = new ArticleDao().GetArticlePage(itemOnPage, pg, out totalArticle);

           return View(articles);
       }

       /// <summary>
       /// Nové knihy
       /// </summary>
       /// <returns>První 3 knihy na úvodní stránku</returns>
       [ChildActionOnly]
       public ActionResult BookNew()
       {
           int itemOnPage = 3;
           int pg = 1;
           int totalBook;

           IList<Book> book = new BookDao().GetBookPage(itemOnPage, pg, out totalBook);

           return View(book);
       }
    }
}
