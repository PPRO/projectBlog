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

namespace WebApplication4.Areas.admin.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index(int? page)
        { 
            int itemOnPage = 10;
            int pg = page ?? 1;
            int totalArticle;

            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;
            IList<Article> articles = new ArticleDao().GetArticlePage(itemOnPage, pg, out totalArticle);

            ViewBag.Pages = (int) Math.Ceiling((double)totalArticle/(double)itemOnPage);
            ViewBag.CurrentPage = pg;
            ViewBag.Category = new ArticleCategoryDao().GetAll();
            
            return View(articles);
        }

        
        public ActionResult ArticleDetail(int id)
        {
            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;
           
            Article article = new ArticleDao().GetById(id);
            

            return View(article);

        }
        /// <summary>
        /// Menu rubrika
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clanky</returns>

        public ActionResult Rubrika(int? id)
        {
            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;
           
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
           
            IList<Article> article = new List<Article>();
            List<int> pouzito = new List<int>();

            IList<Article> articles = new ArticleDao().GetAll();

            foreach ( Article a in articles )
            { 
                bool y = false;
                int d = a.Id;
                if ( pouzito.Count == 0 )
                {


                    pouzito.Add(a.Category.Id);
                    article.Add(a);


                }
                else
                {
                    for (int i = 0; i < pouzito.Count; i++ )
                    {
                         if ( a.Category.Id == pouzito[i] )
                         {
                             y = true;
                         }
                    }
                    if ( !y )
                    {
                        
                            pouzito.Add(a.Category.Id);
                            article.Add(a);

                        
                    }
                   

                }



            }
            return View(article);
        }
        /*
        public ActionResult Create()
        {
                IList<ArticleCategory> categories = new ArticleCategoryDao().GetAll();
                ViewBag.Category = categories;
            
                return View();
        }

        [Authorize]
        public ActionResult EditArticle(int id)
        {

            Article article = new ArticleDao().GetById(id);
            ViewBag.Categories = new ArticleCategoryDao().GetAll();

            return View(article);

        }

       [Authorize]
        public ActionResult DeleteArticle(int id)
        {
            try
            {
                ArticleDao articleDao = new ArticleDao();
                Article article = articleDao.GetById(id);

                if ( article.ImageName != null )
                    System.IO.File.Delete(Server.MapPath("~/image/articleImage/" + article.ImageName));

                articleDao.Delete(article);

                TempData["message-success"] = "Článek" + article.Title + "byla smazan.";
               
            }
            catch ( Exception exception )
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public ActionResult UpdateArticle(Article article, HttpPostedFileBase picture, int categoryId)
        {

            try
            {
                ArticleDao articleDao = new ArticleDao();
                ArticleCategoryDao articleCategoryDao = new ArticleCategoryDao();

                ArticleCategory articleCategory = articleCategoryDao.GetById(categoryId);
                User user = new UserDao().GetByLogin(User.Identity.Name);

                article.Category = articleCategory;
                article.User = user;

                if ( picture != null )
                {
                    if ( picture.ContentType == "image/jpeg" || picture.ContentType == "image/png" )
                    {
                        Image image = Image.FromStream(picture.InputStream);

                        Guid guid = Guid.NewGuid();
                        string imageName = guid.ToString() + ".jpg";

                        if ( image.Height > 200 || image.Width > 200 )
                        {
                            Image small = Helper.ImageHelper.ScaleImage(image, 200, 200);
                            Bitmap b = new Bitmap(small);

                            b.Save(Server.MapPath("~/uploads/articleImage/" + imageName), ImageFormat.Jpeg);

                            small.Dispose();
                            b.Dispose();


                        }
                        else
                        {
                            picture.SaveAs(Server.MapPath("~/uploads/articleImage/" + picture.FileName));
                        }

                        System.IO.File.Delete(Server.MapPath("~/uploads/articleImage/" + article.ImageName));
                        article.ImageName = imageName;
                    };
                }

                articleDao.Update(article);

                TempData["message-success"] = "Článek " + article.Title + " byl upravena.";
            }
            catch ( Exception )
            {

                throw;
            }


            return RedirectToAction("Index");

        } 
        
        [HttpPost]
        public ActionResult AddArticle(Article article, HttpPostedFileBase picture, int categoryId)
        {
            if ( ModelState.IsValid )
            {

                if ( picture != null )
                {
                    if ( picture.ContentType == "image/jpeg" || picture.ContentType == "image/png" )
                    {
                        Image image = Image.FromStream(picture.InputStream);

                        if ( image.Height > 200 || image.Width > 200 )
                        {
                            Image small = Helper.ImageHelper.ScaleImage(image, 200, 200);
                            Bitmap b = new Bitmap(small);

                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";

                            b.Save(Server.MapPath("~/uploads/aticleImage/" + imageName), ImageFormat.Jpeg);
                            b.Save(Server.MapPath("~/uploads/articleImage/" + imageName), ImageFormat.Jpeg);

                            small.Dispose();
                            b.Dispose();

                            article.ImageName = imageName;
                        }
                        else
                        {
                            picture.SaveAs(Server.MapPath("~/uploads/Article/" + picture.FileName));
                        }
                    }
                }
                ArticleCategoryDao articleCategoryDao = new ArticleCategoryDao();




                ArticleCategory articleCategory = articleCategoryDao.GetById(categoryId);
                article.Category = articleCategory;
                article.PosteDate = DateTime.Now;
                article.User = new UserDao().GetByLogin(User.Identity.Name);
                ArticleDao articleDao = new ArticleDao();


                articleDao.Create(article);

                TempData["message-success"] = "Článek byl přidán";

            }
            else
            {
                return View("Create", article);
            }

            return RedirectToAction("Index");
        }*/
    }
}