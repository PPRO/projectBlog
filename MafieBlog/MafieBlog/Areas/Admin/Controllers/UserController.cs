using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Dao;
using DataAccess.Model;
using MafieBlog.Areas.Admin.Models;

namespace MafieBlog.Areas.Admin.Controllers
{
	[Authorize (Roles = "admin")]
    public class UserController : Controller
    {
        // GET: Admin/User
		
        public ActionResult Index()
        {

			IList<BlogUser> users = new BlogUserDao().GetAll();
	       
            return View(users);
        }

	    public ActionResult CreateUser()
	    {

			IList<BlogRole> categories = new BlogRoleDao().GetAll();
			ViewBag.Category = categories;
		    return View();
	    }

	    public ActionResult EditUser(int id)
	    {

			BlogUser user = new BlogUserDao().GetById( id );
			ViewBag.Categories = new BlogRoleDao().GetAll();

			return View( user );
		    
	    }

		[HttpPost]
	    public ActionResult DeleteUser(int id)
		{
			try
			{
			
				BlogUserDao blogUserDao = new BlogUserDao();
				BlogUser user = blogUserDao.GetById( id );

				user.Active = false;

				
				blogUserDao.Update( user );

				TempData["message-success"] = "Uzivatel" + user.Name + "deaktivovan.";
			}
			catch( Exception exception )
			{

				throw;
			}

			return RedirectToAction( "Index" );
		}

		[HttpPost]
		public ActionResult AktivUser( int id )
		{
			try
			{

				BlogUserDao blogUserDao = new BlogUserDao();
				BlogUser user = blogUserDao.GetById( id );

				user.Active = true;


				blogUserDao.Update( user );

				TempData["message-success"] = "Uzivatel" + user.Name + "deaktivovan.";
			}
			catch( Exception exception )
			{

				throw;
			}

			return RedirectToAction( "Index" );
		}

		[HttpPost]
		public ActionResult AddUser(BlogUser user, int categoryId)
		{
			if (ModelState.IsValid)
			{
				BlogUserDao blogUserDao = new BlogUserDao();

				//BlogUser blogUser = blogUserDao.GetById(user.Id);



				BlogRoleDao blogRoleDao = new BlogRoleDao();
				BlogRole blogRole = blogRoleDao.GetById(categoryId);


				user.Role = blogRole;
				user.Active = true;


				blogUserDao.Create(user);

				TempData["message-success"] = "Uzivatel zmenen";

			}
			else
			{
				TempData["message-error"] = "Nepoda5ilo se editovat uzivatele";
			}


			
			
		return RedirectToAction("Index");
			
		}

		[HttpPost]
		public ActionResult UpdateUser( BlogUser user, int categoryId )
		{
			try
			{

				BlogUserDao blogUserDao = new BlogUserDao();
				BlogRoleDao blogRoleDao = new BlogRoleDao();
				BlogRole blogRole = blogRoleDao.GetById( categoryId );
				user.Role = blogRole;

				user.Active = true;


				blogUserDao.Update( user );

				TempData["message-success"] = "Uzivatel" + user.Name + "deaktivovan.";
			}
			catch( Exception exception )
			{

				throw;
			}

			return RedirectToAction( "Index" );
		}
    }
}