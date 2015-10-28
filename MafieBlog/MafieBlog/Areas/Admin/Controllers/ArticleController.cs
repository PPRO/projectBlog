using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MafieBlog.Areas.Admin.Controllers
{
	[Authorize]
	public class ArticleController : Controller
	{
		// GET: Admin/Article
		public ActionResult Index( int? page )
		{

			int itemsOnPage = 5;
			int pg = page ?? 1;
			int totalArticles;

			BlogUser user = new BlogUserDao().GetByLogin( User.Identity.Name );
			int id = user.Id;
			ArticleDao articleDao = new ArticleDao();
			
			IList<Article> article = articleDao.GetArticlePagedByUserId( itemsOnPage, pg, out totalArticles, id );

			ViewBag.Pages = (int)Math.Ceiling( (double)totalArticles / (double)itemsOnPage );
			ViewBag.CurrentPage = pg;
			ViewBag.Category = new ArticleCategoryDao().GetAll();

			return View( article );
		}

		
		[HttpPost]
		public ActionResult AddArticle( Article article, HttpPostedFileBase picture, int categoryId )
		{
			if( ModelState.IsValid )
			{

				if( picture != null )
				{
					if( picture.ContentType == "image/jpeg" || picture.ContentType == "image/png" )
					{
						Image image = Image.FromStream( picture.InputStream );

						if( image.Height > 200 || image.Width > 200 )
						{
							Image small = Class.ImageHelper.ScaleImage( image, 200, 200 );
							Bitmap b = new Bitmap( small );

							Guid guid = Guid.NewGuid();
							string imageName = guid.ToString() + ".jpg";

							b.Save( Server.MapPath( "~/uploads/aticleImage/" + imageName ), ImageFormat.Jpeg );
							b.Save( Server.MapPath( "~/uploads/articleImage/" + imageName ), ImageFormat.Jpeg );

							small.Dispose();
							b.Dispose();

							article.ImageName = imageName;
						}
						else
						{
							picture.SaveAs( Server.MapPath( "~/uploads/Article/" + picture.FileName ) );
						}
					}
				}
				ArticleCategoryDao articleCategoryDao = new ArticleCategoryDao();




				ArticleCategory articleCategory = articleCategoryDao.GetById( categoryId );
				article.Category = articleCategory;
				article.PostDate = DateTime.Now;
				article.User = new BlogUserDao().GetByLogin(User.Identity.Name);
				ArticleDao articleDao = new ArticleDao();


				articleDao.Create( article );

				TempData["message-success"] = "Kniha byla pridana";

			}
			else
			{
				return View( "Create", article );
			}

			return RedirectToAction( "Index" );
		}

		
		public ActionResult EditArticle( int id )
		{

			Article article = new ArticleDao().GetById( id );
			ViewBag.Categories = new ArticleCategoryDao().GetAll();

			return View( article );

		}

		[Authorize( Roles = "admin" )]
		public ActionResult DeleteArticle( int id )
		{
			try
			{
				ArticleDao articleDao = new ArticleDao();
				Article article = articleDao.GetById( id );

				if( article.ImageName != null )
					System.IO.File.Delete( Server.MapPath( "~/uploads/articleImage/" + article.ImageName ) );

				articleDao.Delete( article );

				TempData["message-success"] = "Článek" + article.Title + "byla smazan.";
			}
			catch( Exception exception )
			{

				throw;
			}

			return RedirectToAction( "Index" );
		}
		
		[HttpPost]
		public ActionResult UpdateArticle( Article article, HttpPostedFileBase picture, int categoryId )
		{

			try
			{
				ArticleDao articleDao = new ArticleDao();
				ArticleCategoryDao articleCategoryDao = new ArticleCategoryDao();

				ArticleCategory articleCategory = articleCategoryDao.GetById( categoryId );
				BlogUser user = new BlogUserDao().GetByLogin(User.Identity.Name);
				
				article.Category = articleCategory;
				article.User = user;
			
				if( picture != null )
				{
					if( picture.ContentType == "image/jpeg" || picture.ContentType == "image/png" )
					{
						Image image = Image.FromStream( picture.InputStream );

						Guid guid = Guid.NewGuid();
						string imageName = guid.ToString() + ".jpg";

						if( image.Height > 200 || image.Width > 200 )
						{
							Image small = Class.ImageHelper.ScaleImage( image, 200, 200 );
							Bitmap b = new Bitmap( small );

							b.Save( Server.MapPath( "~/uploads/articleImage/" + imageName ), ImageFormat.Jpeg );

							small.Dispose();
							b.Dispose();


						}
						else
						{
							picture.SaveAs( Server.MapPath( "~/uploads/articleImage/" + picture.FileName ) );
						}

						System.IO.File.Delete( Server.MapPath( "~/uploads/articleImage/" + article.ImageName ) );
						article.ImageName = imageName;
					};
				}

				articleDao.Update( article );

				TempData["message-success"] = "Kniha" + article.Title + "byla upravena.";
			}
			catch( Exception )
			{

				throw;
			}


			return RedirectToAction( "Index", "Article" );

		}


		public ActionResult Create()
		{
			IList<ArticleCategory> categories = new ArticleCategoryDao().GetAll();
			ViewBag.Category = categories;

			BlogUser blogUser = new BlogUserDao().GetByLogin(User.Identity.Name);
			ViewBag.User = blogUser.Login;
			return View();
		}


	}
}