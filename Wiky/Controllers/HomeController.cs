using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wiky.Models;
using Wiky.Repository;

namespace Wiky.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Article article = new ArticleRepository().FindLastArticle();

            return View(article);
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
    }
}