using DataAccess.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using DataAccess.Dao;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;

namespace MafieBlog.Controllers
{
	
    public class RubrikaController : Controller
    {
        // GET: Rubrika
		
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

	    [HttpPost]
	    public ActionResult AddComment(BlogComment comment)
	    {


		    if (ModelState.IsValid)
		    {
			  
				BlogCommentDao blogComment = new BlogCommentDao();
				comment.CommentDate = DateTime.Now;

			    blogComment.Create(comment);
			    TempData["message-success"] = "Komentář přidán";

		    }

		    return RedirectToAction("ArticleDetail");
	    }

	    public ActionResult ShowComment(int id)
	    {
		    int totalComment;
		    IList<BlogComment> comments = new BlogCommentDao().GetCommentByArticleId(out totalComment, id);
		    ViewBag.Comment = totalComment;
			return View(comments);
	    }

	    public ActionResult Comment(bool id)
	    {

		    ViewBag.IdArticle = id;

		    return View();
	    }
    }
}