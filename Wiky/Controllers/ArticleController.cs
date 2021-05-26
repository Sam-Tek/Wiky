﻿using System;
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
        public ActionResult AjouterArticle(Article article)
        {
            article.DateCreation = DateTime.Now;
            article = new ArticleRepository().AddOneArticle(article);

            if (article == null)
                ViewBag.MessageAjout = "Erreur";
            else
                ViewBag.MessageAjout = "L'article est ajouté";
            return View();
        }

        public ActionResult VoirArticle(int id = 2)
        {
            Article article = new ArticleRepository().FindOneById(id);

            if (article == null)
                return RedirectToAction("Index");

            return View(article);
        }
    }
}