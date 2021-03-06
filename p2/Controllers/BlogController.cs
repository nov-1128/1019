﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p2.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index(string q)
        {
            var db = new BlogDB();
            db.Database.CreateIfNotExists();

            var lst = db.BlogArticles.AsQueryable();
            if (!string.IsNullOrWhiteSpace(q))
            {
                lst = lst.Where(o => o.Subject.Contains(q));
            }
            ViewBag.BlogArticles = lst.OrderByDescending(o => o.ID).ToList();
            ViewBag.q = q;

            return View();
        }
        public ActionResult AddArticle()
        {

            if (Request.Cookies["isauth"] != null && Request.Cookies["isauth"].Value == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "CookieCount");
            }
        }

       // public ActionResult ArticleSave(string subject, string body)
       public ActionResult ArticleSave(BlogArticle model)
        { /*
            var article = new BlogArticle();
            // article.Subject = subject;
            article.Subject = model.Subject;
            // article.Body = body;
            article.Body = model.Body;
            article.CreTime = DateTime.Now;

            var db = new BlogDB();
            db.BlogArticles.Add(article);
            db.SaveChanges();*/
            if (ModelState.IsValid) {
                var article = new BlogArticle();              
                article.Subject = model.Subject;              
                article.Body = model.Body;
                article.CreTime = DateTime.Now;

                var db = new BlogDB();
                db.BlogArticles.Add(article);
                db.SaveChanges();
            }
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