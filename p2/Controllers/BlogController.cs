using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p2.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            var db = new BlogDB();

            db.Database.CreateIfNotExists();

            var lst = db.BlogArticles.OrderByDescending(o => o.ID).ToList();
            ViewBag.BlogArticles = lst;

            return View();
        }
        public ActionResult AddArticle()
        {
            return View();
        }

        public ActionResult ArticleSave(string subject, string body)
        {
            var article = new BlogArticle();
            article.Subject = subject;
            article.Body = body;
            article.CreTime = DateTime.Now;

            var db = new BlogDB();
            db.BlogArticles.Add(article);
            db.SaveChanges();
            return Redirect("Index");
           // return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            var db = new BlogDB();
            var article = db.BlogArticles.First(o => o.ID == id);

            ViewData.Model = article;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var db = new BlogDB();
            var article = db.BlogArticles.First(o => o.ID == id);

            ViewData.Model = article;
            return View();
        }

        public ActionResult EditSave(int id, string subject, string body)
        {
            var db = new BlogDB();
            var article = db.BlogArticles.First(o => o.ID == id);

            article.Subject = subject;
            article.Body = body;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 删除博文
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var db = new BlogDB();
            var article = db.BlogArticles.First(o => o.ID == id);

            db.BlogArticles.Remove(article);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}