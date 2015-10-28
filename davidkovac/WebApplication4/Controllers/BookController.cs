using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.DAO;
using DataAccess.Model;

namespace WebApplication4.Controllers
{
    /// <summary>
    /// Třída pro práci s knihami
    /// </summary>
    public class BookController : Controller
    {
        // GET: Book
        /// <summary>
        /// Seznam všech knih
        /// </summary>
        /// <param name="page"></param>
        /// <returns>knihy</returns>
        public ActionResult Index(int? page)
        {
            int itemOnPage = 5;
            int pg = page ?? 1;
            int totalBook;

            IList<Book> book = new BookDao().GetBookPage(itemOnPage, pg, out totalBook);
            // Stránkování
            ViewBag.Pages = (int)Math.Ceiling((double)totalBook / (double)itemOnPage);
            ViewBag.CurrentPage = pg;
           
            ViewBag.Category = new BookCategoryDao().GetAll();

            return View(book);
        }
        /// <summary>
        /// Detail knihy
        /// </summary>
        /// <param name="id">Identifikační číslo knihy</param>
        /// <returns>¨detail knihy</returns>
        public ActionResult BookDetail(int id)
        {
            Book book = new BookDao().GetById(id);
            return View(book);

        }
    }
}