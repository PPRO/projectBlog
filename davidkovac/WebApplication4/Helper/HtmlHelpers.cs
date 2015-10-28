using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.UI;
using DataAccess.Model;
using DataAccess.DAO;
using WebApplication4.Controllers;
using RouteDataValueProvider = System.Web.ModelBinding.RouteDataValueProvider;

namespace WebApplication4.Helper
{
    /// <summary>
    /// Pomocná třída přiřazuje class = "aktiv" k aktivnímu odkazu v menu
    /// </summary>
	public static class HtmlHelpersExtension
	{
		public static string LastAction;
		public static string LastController;
        public static string LastAct;
        public static string Id;

        
        /// <summary>
        ///  Projde všechny Menu Linky na aktuální stránce a přiřadí hodnotu classValue k aktivnímu linku
        /// dle, action a controlleru
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="action">uživatelem požadováná akce</param>
        /// <param name="controller">kontroler požadované akce</param>
        /// <returns>classValue="active"</returns>
		public static string MenuLink( this HtmlHelper htmlHelper, string action, string controller, int rubrika)
        {
            string classValue = "";
            //akce odkazu
            string currentAction = htmlHelper.ViewContext.Controller.ValueProvider.GetValue( "action" ).RawValue.ToString();

            // controller odkazu
			string currentController =
					htmlHelper.ViewContext.Controller.ValueProvider.GetValue( "controller" ).RawValue.ToString();
            /*
             * Předávání aktiv class, když se jde přes rubriku
             */
            if (rubrika != 0)
            {

                if ( currentAction == "MenuRubrika" )
                {
                    LastAction = "Rubrika";
                    LastController = currentController;

                    string r = rubrika.ToString();

                    if ( r == Id )
                    {
                        classValue = "active";
                    }

                }
           
            }

            /*
             * Při přechodu na detail článku,
             * ponechá aktiv u blogu 
             * 
             */
			if (currentAction == "ArticleDetail")
			{
                /*
                 * Při přechodu na detail článku z hlavní stránky = Novinky,
                 * zajistí aktiv u blogu
                 */
                if ( currentController == "Blog" )
                {
                    LastAction = currentAction;
                    LastController = currentController;

                    /*
                     * Porvná zda se shodují uživatelem požadovaný controller s controllerem odkazu
                     */
                    if ( controller == currentController )
                    {
                        classValue = "active";
                    }
                }
                /*
                 * Detail článku z blogu
                 * 
                 */
                else
			    {
			        currentAction = LastAction;
			        currentController = LastController;
                    /*
                     * porovná akce i kontroler
                     */
			        if (controller == currentController && action == currentAction)
			        {
			            classValue = "active";
			        }
                   
			    }

			}

            /*
             * Při přechodu na detail knihy,
             * ponechá aktiv u knihy 
             * 
             */
            if ( currentAction == "BookDetail" )
            {
                /*
                 * Při přechodu na detail knihy z hlavní stránky = Novinky,
                 * zajistí aktiv u knihy
                 */
                if ( currentController == "Book" )
                {
                    LastAction = currentAction;
                    LastController = currentController;
                    /*
                    * Porvná zda se shodují uživatelem požadovaný controller s controllerem odkazu
                    */
                    if ( controller == currentController )
                    {
                        classValue = "active";
                    }
            }
            /*
             * Detail článku z blogu
             * 
             */
            else
            {
                 currentAction = LastAction;
                 currentController = LastController;
                 /*
                  * porovná akce i kontroler
                  */
                 if (controller == currentController && action == currentAction)
                 {
                     classValue = "active";
                 }
            }

            }
            /*
             * porovná akce a kontroler z hlávního menu
             */	
			if( controller == currentController && action == currentAction )
			{
					LastAction = currentAction;
					LastController = currentController;
					classValue = "active";
            }
            else
            {
                /*
                 * Uchová aktivní link v menu
                 */
                if ( controller == currentController )
                {
                    if ( currentAction == "Rubrika" )
                    {
                        classValue = "active";
                    }
                }
            }
                
			
		return classValue;

		}
	}
}