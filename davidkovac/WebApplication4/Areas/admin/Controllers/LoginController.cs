﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccess.DAO;
using DataAccess.Model;


namespace WebApplication4.Areas.admin.Controllers
{
	public class LoginController : Controller
	{
		// GET: Login
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SignIn(string login, string password)
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

			return RedirectToAction( "Index", "Home" );
		}
	}
}