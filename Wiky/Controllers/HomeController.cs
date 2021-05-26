using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wiky.Models;

namespace Wiky.Controllers
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

        public ActionResult AjouterArticle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AjouterArticle(Article article)
        {
            article.DateCreation = DateTime.Now;

            Wikydb context = new Wikydb();
            context.Article.Add(article);
            context.SaveChanges();

            ViewBag.MessageAjout = "L'article est ajouté";
            return View();
        }

        public ActionResult VoirArticle(int id = 2)
        {
            Wikydb context = new Wikydb();
            Article article = context.Article.FirstOrDefault(a => a.Id == id);

            if (article == null)
                return RedirectToAction("Index");

            return View(article);
        }
    }
}