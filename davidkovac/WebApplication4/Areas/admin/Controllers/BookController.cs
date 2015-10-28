using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.DAO;
using DataAccess.Model;

namespace WebApplication4.Areas.admin.Controllers
{
    public class BookController : Controller
    {
        // GET: Books
        public ActionResult Index(int? page)
        {
            int itemOnPage = 10;
            int pg = page ?? 1;
            int totalBook;

            IList<Book> book = new BookDao().GetBookPage(itemOnPage, pg, out totalBook);

            ViewBag.Pages = (int)Math.Ceiling((double)totalBook / (double)itemOnPage);
            ViewBag.CurrentPage = pg;
            ViewBag.Category = new BookCategoryDao().GetAll();

            return View(book);
        }

        public ActionResult BookDetail(int id)
        {

            Book book = new BookDao().GetById(id);


            return View(book);

        }

        public ActionResult Create()
        {
            IList<BookCategory> categories = new BookCategoryDao().GetAll();
            ViewBag.Category = categories;

            return View();
        }

        [Authorize]
        public ActionResult EditBook(int id)
        {

            Book book = new BookDao().GetById(id);
            ViewBag.Categories = new BookCategoryDao().GetAll();

            return View(book);

        }

        [Authorize]
        public ActionResult DeleteBook(int id)
        {
            try
            {
                BookDao bookDao = new BookDao();
                Book book = bookDao.GetById(id);

                if ( book.ImageName != null )
                    System.IO.File.Delete(Server.MapPath("~/image/articleImage/" + book.ImageName));

                bookDao.Delete(book);

                TempData["message-success"] = "Článek" + book.Title + "byla smazan.";

            }
            catch ( Exception exception )
            {

                throw;
            }

            return RedirectToAction("Index");
        }

      
        [HttpPost]
        public ActionResult UpdateBook(Book book, HttpPostedFileBase picture, int categoryId)
        {

            try
            {
                BookDao bookDao = new BookDao();
                BookCategoryDao bookCategoryDao = new BookCategoryDao();

                BookCategory bookCategory = bookCategoryDao.GetById(categoryId);
                User user = new UserDao().GetByLogin(User.Identity.Name);

                book.Category = bookCategory;
                
                if ( picture != null )
                {
                    if ( picture.ContentType == "image/jpeg" || picture.ContentType == "image/png" )
                    {
                        Image image = Image.FromStream(picture.InputStream);

                        Guid guid = Guid.NewGuid();
                        string imageName = guid.ToString() + ".jpg";

                        if ( image.Height > 200 || image.Width > 200 )
                        {
                            Image small = Helper.ImageHelper.ScaleImage(image, 200, 200);
                            Bitmap b = new Bitmap(small);

                            b.Save(Server.MapPath("~/uploads/articleImage/" + imageName), ImageFormat.Jpeg);

                            small.Dispose();
                            b.Dispose();


                        }
                        else
                        {
                            picture.SaveAs(Server.MapPath("~/uploads/articleImage/" + picture.FileName));
                        }

                        System.IO.File.Delete(Server.MapPath("~/uploads/articleImage/" + book.ImageName));
                        book.ImageName = imageName;
                    };
                }

                bookDao.Update(book);

                TempData["message-success"] = "Článek " + book.Title + " byl upravena.";
            }
            catch ( Exception )
            {

                throw;
            }


            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Addbook(Book book, HttpPostedFileBase picture, int categoryId)
        {
            if ( ModelState.IsValid )
            {

                if ( picture != null )
                {
                    if ( picture.ContentType == "image/jpeg" || picture.ContentType == "image/png" )
                    {
                        Image image = Image.FromStream(picture.InputStream);

                        if ( image.Height > 200 || image.Width > 200 )
                        {
                            Image small = Helper.ImageHelper.ScaleImage(image, 200, 200);
                            Bitmap b = new Bitmap(small);

                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";

                            b.Save(Server.MapPath("~/uploads/aticleImage/" + imageName), ImageFormat.Jpeg);
                            b.Save(Server.MapPath("~/uploads/articleImage/" + imageName), ImageFormat.Jpeg);

                            small.Dispose();
                            b.Dispose();

                            book.ImageName = imageName;
                        }
                        else
                        {
                            picture.SaveAs(Server.MapPath("~/uploads/Article/" + picture.FileName));
                        }
                    }
                }
                BookCategoryDao bookCategoryDao = new BookCategoryDao();




                BookCategory bookCategory = bookCategoryDao.GetById(categoryId);
                book.Category = bookCategory;
                book.PosteDate = DateTime.Now;
                BookDao bookDao = new BookDao();


                bookDao.Create(book);

                TempData["message-success"] = "Článek byl přidán";

            }
            else
            {
                return View("Create", book);
            }

            return RedirectToAction("Index");
        }
    }
}