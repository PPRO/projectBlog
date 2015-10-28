using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MafieBlog.Areas.Admin.Controllers
{
	[Authorize]
    public class MenuLeftController : Controller
    {
        // GET: Admin/MenuLeft
		[ChildActionOnly]
        public ActionResult Index()
        {

			BlogUserDao blogUserDao = new BlogUserDao();
			BlogUser blogUser = blogUserDao.GetByLogin(User.Identity.Name);
			 
            return View(blogUser);
        }

		[ChildActionOnly]
		public ActionResult Menu()
		{
			BlogUser blogUser = new BlogUserDao().GetByLogin(User.Identity.Name);

			return View(blogUser);
		}
	
    }
}