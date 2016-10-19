using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult List()
        {
            string[] data = new string[] { "Noms：灵感来自Git的数据库",
                "微软开源LightGBM：轻量级梯度Boosting框架",
                "Cassandra和Mesos协调运作：Uber跨多个数据中心高速运行",
                "携程风险防御体系的变革之路",
            };
            ViewBag.data = data;
            ViewData["data"] = data;
            ViewData.Model = data;
            return View();
        }
    }
}