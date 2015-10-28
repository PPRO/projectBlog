using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Dao;
using DataAccess.Model;

namespace MafieBlog.Areas.Admin.Controllers
{
	[Authorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
			BlogUser blogUser  = new BlogUserDao().GetByLogin( User.Identity.Name );
	        ViewBag.Pozdrav = blogUser.Name;
            return View();
        }
    }
}