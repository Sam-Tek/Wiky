using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wiky.Models;
using Wiky.Repository;

namespace Wiky.Controllers
{
    public class ArticleController : Controller
    {
        //lister les articles
        public ActionResult Index()
        {
            return View(new ArticleRepository().FindAllArticle());
        }

        public ActionResult AjouterArticle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjouterArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                article.DateCreation = DateTime.Now;
                article = new ArticleRepository().AddOneArticle(article);

                if (article == null)
                    TempData["MessageAjout"] = "Erreur";
                else
                    TempData["MessageAjout"] = "L'article est ajouté";
                return View("AjouterArticle");

            }
            else
                return RedirectToAction(Request.UrlReferrer.ToString());
        }

        public ActionResult VoirArticle(int id = 0)
        {
            Article article = new ArticleRepository().FindOneArticleById(id);

            Commentaire commentaire = new Commentaire() { ArticleId = article.Id };
            ViewBag.commentaire = commentaire;

            if (article == null)
                return RedirectToAction("Index");

            return View(article);
        }

        public ActionResult SupprimerArticle(int id = 0)
        {
            Article article = new ArticleRepository().DelOneArticle(id);

            if (article == null)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index");
        }

        public ActionResult ModifierArticle(int id = 0)
        {
            Article article = new ArticleRepository().FindOneArticleById(id);

            if (article != null)
                return View(article);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifierArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                article = new ArticleRepository().AmendArticle(article);

                if (article != null)
                {
                    ViewBag.Message = "Modification validée";
                    return View(article);
                }

                return RedirectToAction("Index");
            }
            else
                return RedirectToAction(Request.UrlReferrer.ToString());
        }

        public ActionResult ThemeUnique(string theme, int Id = 0)
        {
            List<Article> articles = new ArticleRepository().FindArticleByTheme(theme);
            Article articleBDD = articles.FirstOrDefault(a => a.Id == Id);
            if (articles.Count == 0 || (articles.Count == 1 && articleBDD != null))
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}