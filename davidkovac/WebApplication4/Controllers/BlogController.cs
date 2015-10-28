using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.DAO;
using DataAccess.Model;
using WebApplication4.Helper;

namespace WebApplication4.Controllers
{
    
    /// <summary>
    /// Třída pro práci s blogem
    /// </summary>
    public class BlogController : Controller
    {
        // GET: Blog

        /// <summary>
        /// Seznam všech článků
        /// </summary>
        /// <param name="page"></param>
        /// <returns>články</returns>
        public ActionResult Index(int? page)
        { 
            int itemOnPage = 5;
            int pg = page ?? 1;
            int totalArticle;

            IList<Article> articles = new ArticleDao().GetArticlePage(itemOnPage, pg, out totalArticle);

            // Stránkování - max 5 článků
            ViewBag.Pages = (int) Math.Ceiling((double)totalArticle/(double)itemOnPage);
            ViewBag.CurrentPage = pg;

            // všechny kategorie článků
            ViewBag.Category = new ArticleCategoryDao().GetAll();
            return View(articles);
        }

        /// <summary>
        /// Detail článku
        /// </summary>
        /// <param name="id">Identifikační číslo článku</param>
        /// <returns>detail článku</returns>
        public ActionResult ArticleDetail(int? id)
        {
            int i = id ?? 0;
            if ( i == 0 )
            {
                return RedirectToAction("Index");
            }
            else
            {
                
                Article article = new ArticleDao().GetById(i);
                return View(article);
            }
         
           
        }
        /// <summary>
        /// Menu rubrika
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clanky</returns>
       
        public ActionResult Rubrika(int? id)
        {
            int i = id ?? 0;
            if ( i == 0 )
            {
                return RedirectToAction("Index");
            }
            else
            {
                IList<Article> article = new ArticleDao().GetArticleInCategoryId(i);
                ViewBag.Categoties = new ArticleCategoryDao().GetAll();
                /*
                 * predani identifikacniho cisla htmlHelpers pro porovnani
                 */
                HtmlHelpersExtension.Id = id.ToString();
                return View("Index", article);
            }
            
        }

        /// <summary>
        /// Generuje menu rubrika
        /// </summary>
        /// <returns>clanky</returns>
        [ChildActionOnly]
        public ActionResult MenuRubrika()
        {
            {

                IList<Article> article = new List<Article>();
                List<int> pouzito = new List<int>();

                IList<Article> articles = new ArticleDao().GetAll();

                foreach (Article a in articles)
                {
                    bool y = false;
                    int d = a.Id;
                    if (pouzito.Count == 0)
                    {


                        pouzito.Add(a.Category.Id);
                        article.Add(a);


                    }
                    else
                    {
                        for (int i = 0; i < pouzito.Count; i++)
                        {
                            if (a.Category.Id == pouzito[i])
                            {
                                y = true;
                            }
                        }
                        if (!y)
                        {

                            pouzito.Add(a.Category.Id);
                            article.Add(a);


                        }


                    }



                }

                return View(article);
            }
        }
    }
}