using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using DataAccess.Model;
using DataAccess.Dao;

namespace MafieBlog.Class
{		


		
	public static class HtmlHelpersExtension
	{	
	
		public static string LastAction;
		public static string LastController;

		public static string MenuLink( this HtmlHelper htmlHelper, string action, string controller)
		{
			string classValue = "";

			
			
				string currentAction = htmlHelper.ViewContext.Controller.ValueProvider.GetValue( "action" ).RawValue.ToString();
				string currentController =
					htmlHelper.ViewContext.Controller.ValueProvider.GetValue( "controller" ).RawValue.ToString();
				
			if (currentAction == "ArticleDetail")
			{
				
						currentAction = LastAction;
						currentController = LastController;

						if (controller == currentController && action == currentAction)
						{
							classValue = "active";
						}
				
				
			}
				

				if( controller == currentController && action == currentAction )
				{
					LastAction = currentAction;
					LastController = currentController;
					classValue = "active";
				}
			
		return classValue;

		}
	}
}