using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.DAO;
using DataAccess.Model;

namespace WebApplication4.Areas.admin.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: admin/Administration
        public ActionResult Index(int? page)
        {
            int itemOnPage = 10;
            int pg = page ?? 1;
            int totalArticle;

            IList<Article> articles = new ArticleDao().GetArticlePage(itemOnPage, pg, out totalArticle);

            ViewBag.Pages = (int) Math.Ceiling((double) totalArticle/(double) itemOnPage);
            ViewBag.CurrentPage = pg;
            ViewBag.Category = new ArticleCategoryDao().GetAll();

            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;

            return View(articles);
        }

        /*
        public ActionResult SeznamBook(int? page)
        {
            int itemOnPage = 10;
            int pg = page ?? 1;
            int totalBook;

            IList<Book> book = new BookDao().GetBookPage(itemOnPage, pg, out totalBook);

            ViewBag.Pages = (int) Math.Ceiling((double) totalBook/(double) itemOnPage);
            ViewBag.CurrentPage = pg;
            ViewBag.Category = new BookCategoryDao().GetAll();

            return View(book);
        }
        */

        public ActionResult Kategorie(int? page)
        {
            int itemOnPage = 10;
            int pg = page ?? 1;
            int totalKategorie;

            IList<ArticleCategory> kategorie = new ArticleCategoryDao().GetArticleCategories(out totalKategorie);

            ViewBag.Pages = (int) Math.Ceiling((double) totalKategorie/(double) itemOnPage);
            ViewBag.CurrentPage = pg;
            ViewBag.Category = new BookCategoryDao().GetAll();
            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;

            return View(kategorie);
        }

        /*
        public ActionResult Gener(int? page)
        {
            int itemOnPage = 10;
            int pg = page ?? 1;
            int totalGener;

            IList<BookCategory> bookCategory = new BookCategoryDao().GetBookCategories(out totalGener);

            ViewBag.Pages = (int) Math.Ceiling((double) totalGener/(double) itemOnPage);
            ViewBag.CurrentPage = pg;
            ViewBag.Category = new BookCategoryDao().GetAll();

            return View(bookCategory);
        }
        */

        public ActionResult CreateArticle()
        {
            IList<ArticleCategory> categories = new ArticleCategoryDao().GetAll();
            ViewBag.Category = categories;

            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;

            return View();
        }

        public ActionResult CreateCategory()
        {
            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;
            return View();
        }


        public ActionResult EditArticle(int id)
        {
            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;
            Article article = new ArticleDao().GetById(id);
            ViewBag.Category = new ArticleCategoryDao().GetAll();

            return View(article);

        }

        public ActionResult EditCategory(int id)
        {
            User user = new UserDao().GetByLogin(User.Identity.Name);
            ViewBag.User = user.Name;
            ArticleCategory category = new ArticleCategoryDao().GetById(id);


            return View(category);

        }


        public ActionResult DeleteArticle(int id)
        {
            try
            {
                ArticleDao articleDao = new ArticleDao();
                Article article = articleDao.GetById(id);

                if (article.ImageName != null)
                    System.IO.File.Delete(Server.MapPath("~/image/articleImage/" + article.ImageName));

                articleDao.Delete(article);

                TempData["message-success"] = "Článek" + article.Title + "byla smazan.";

            }
            catch (Exception exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            int i = id;
            IList<Article> article = new ArticleDao().GetArticleInCategoryId(id);
            if (article.Count == 0 )
            {
                ArticleCategory category = new ArticleCategoryDao().GetById(id);
                new ArticleCategoryDao().Delete(category);
                TempData["message-success"] = "Kategorie byla smazána";

                return RedirectToAction("Kategorie");
            }
            TempData["message-unsuccess"] =
                "Kategorie je použita u těchto článků. Před smazáním kategorie je potřeba změnit kategorii u článků!";

            return RedirectToAction("Rubrika", "Blog", routeValues: new
            {
                id = i
            });
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

                if (picture != null)
                {
                    if (picture.ContentType == "image/jpeg" || picture.ContentType == "image/png")
                    {
                        Image image = Image.FromStream(picture.InputStream);

                        Guid guid = Guid.NewGuid();
                        string imageName = guid.ToString() + ".jpg";

                        if (image.Height > 200 || image.Width > 200)
                        {
                            Image small = Helper.ImageHelper.ScaleImage(image, 200, 200);
                            Bitmap b = new Bitmap(small);

                            b.Save(Server.MapPath("~/image/articleImage/" + imageName), ImageFormat.Jpeg);

                            small.Dispose();
                            b.Dispose();


                        }
                        else
                        {
                            picture.SaveAs(Server.MapPath("~/image/articleImage/" + picture.FileName));
                        }

                  System.IO.File.Delete(Server.MapPath("~/image/articleImage/" + article.ImageName));
                  article.ImageName = imageName;
                    }
                    ;
                }

                articleDao.Update(article);

                TempData["message-success"] = "Článek " + article.Title + " byl upravena.";
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult UpdateCategory(ArticleCategory category)
        {
            try
            {
                new ArticleCategoryDao().Update(category);

                TempData["message-success"] = "Kategorie byla upravena.";
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("Kategorie");

        }

        [HttpPost]
        public ActionResult AddArticle(Article article, HttpPostedFileBase picture, int categoryId)
        {
            if (ModelState.IsValid)
            {
                 IList<Article> art = new ArticleDao().GetAll();

                foreach (Article a in art)
                {
                    if (a.Title == article.Title)
                    {
                        TempData["message-unsuccess"] = "Nadpis už existuje";
                        IList<ArticleCategory> categories = new ArticleCategoryDao().GetAll();
                        ViewBag.Category = categories;
                        return View("CreateArticle", article);
                    }
                    
                }
                      
            

                if (picture != null)
                {
                    if (picture.ContentType == "image/jpeg" || picture.ContentType == "image/png")
                    {
                        Image image = Image.FromStream(picture.InputStream);

                        if (image.Height > 200 || image.Width > 200)
                        {
                            Image small = Helper.ImageHelper.ScaleImage(image, 200, 200);
                            Bitmap b = new Bitmap(small);

                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";

                            b.Save(Server.MapPath("~/image/aticleImage/" + imageName), ImageFormat.Jpeg);
                            b.Save(Server.MapPath("~/image/articleImage/" + imageName), ImageFormat.Jpeg);

                            small.Dispose();
                            b.Dispose();

                            article.ImageName = imageName;
                        }
                        else
                        {
                            picture.SaveAs(Server.MapPath("~/image/articleImage/" + picture.FileName));
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
                IList<ArticleCategory> categories = new ArticleCategoryDao().GetAll();
                ViewBag.Category = categories;
                return View("CreateArticle", article);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddArticleCategory(ArticleCategory category)
        {
            if (ModelState.IsValid)
            {
                IList<ArticleCategory> cat = new ArticleCategoryDao().GetAll();

                foreach (ArticleCategory c in cat)
                {
                    if (c.Name == category.Name)
                    {
                        TempData["message-unsuccess"] = "Kategorie už existuje";
                        return View("CreateCategory", category);
                    }
                    
                }
                        new ArticleCategoryDao().Create(category);
                        TempData["message-success"] = "Nová kategorie byla přidána";
            }
            else
            {
                return View("CreateCategory", category);
            }
            
            return RedirectToAction("Kategorie");

        }



    }
}