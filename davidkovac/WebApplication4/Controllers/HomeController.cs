using DataAccess.DAO;
using DataAccess.Model;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Helper;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        /// <summary>
        /// Úvodní stránka
        /// </summary>
        /// <returns>Úvodní stránku</returns>
        public ActionResult Index()
        {

            return View();

        }
        /// <summary>
        /// Stránka o autorovi
        /// </summary>
        /// <returns>Stránka o autorovi</returns>
        public ActionResult AboutMe()
        {
            return View();
        }
        /// <summary>
        /// Kontaktní údaje
        /// </summary>
        /// <returns>Kontakt</returns>
        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// Nové články
        /// </summary>
        /// <returns>První 3 články na úvodní stránku</returns>
        [ChildActionOnly]
        public ActionResult ArticleNew()
        {
            int itemOnPage = 3;
            int pg = 1;
            int totalArticle;
            
            IList<Article> articles = new ArticleDao().GetArticlePage(itemOnPage, pg, out totalArticle);

            return View(articles);
        }

        /// <summary>
        /// Nové knihy
        /// </summary>
        /// <returns>První 3 knihy na úvodní stránku</returns>
        [ChildActionOnly]
        public ActionResult BookNew()
        {
            int itemOnPage = 3;
            int pg = 1;
            int totalBook;
               
            IList<Book> book = new BookDao().GetBookPage(itemOnPage, pg, out totalBook);

            return View(book);
        }

        [HttpPost]
        public ViewResult SendMessage(Mail message)
        {
            if ( ModelState.IsValid )
            {
                
                MailMessage mail = new MailMessage();
                string to = "invisighote@seznam.cz";
                mail.To.Add(to);
                mail.From = new MailAddress(message.From);
                string sub = "Zpráva ze stránek";
                mail.Subject = sub;
                string body = message.Body;
                mail.Body = body;
                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("invisighote83@gmail.cz", "rPkD3ojb");// Enter seders User name and password 
                smtp.EnableSsl = true;
                
                smtp.Send(mail);
                TempData["message-success"] = "Zpráva odeslána";
                return View("Contact");
            }
            else
            {
                return View("Contact", message);
            }
        }

        public ActionResult Download()
        {
            return File("~/document/david_kovac_cv.pdf", "application/pdf", "KovacCV.pdf");
        }
        
        /// <summary>
        /// Nastvení jazyka stránky
        /// </summary>
        /// <param name="culture"> cs, en</param>
        /// <returns>web v nastaveném jazyce</returns>
  
        [Authorize]
        public ActionResult SetCulture(string culture)
        {string control;
            // ověření inputu
            culture = CultureHelper.GetImplementedCulture(culture);
            RouteData.Values["culture"] = culture;  // nastavení jazyku v routu
            // Uloží culture v cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if ( cookie != null )
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
    }
}
