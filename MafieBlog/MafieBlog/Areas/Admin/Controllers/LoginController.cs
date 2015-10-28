using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccess.Dao;
using DataAccess.Model;
using MafieBlog.Areas.Admin.Models;

namespace MafieBlog.Areas.Admin.Controllers
{
	public class LoginController : Controller
	{
		// GET: Login
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SignIn(string login, string password, string mem)
		{
				
				if (Membership.ValidateUser(login, password))
				{
					FormsAuthentication.SetAuthCookie(login, false);

					return RedirectToAction("Index", "Home");
				}
		

		TempData["error"] = "Login nebo heslo neni spravne.";
			return RedirectToAction( "Index", "Login" );
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			Session.Clear();

			return RedirectToAction( "Index", "Login" );
		}
	}
}