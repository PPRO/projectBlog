﻿using System.Web.Mvc;

namespace WebApplication4.Areas.admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
				namespaces: new[] {"WebApplication4.Areas.Admin.Controllers"}
            );
        }
    }
}