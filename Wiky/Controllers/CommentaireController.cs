using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wiky.Models;
using Wiky.Repository;

namespace Wiky.Controllers
{
    public class CommentaireController : Controller
    {
        //lister les articles
        public ActionResult Index()
        {
            return View(new CommentaireRepository().FindAllCommentaire());
        }

        public ActionResult AjouterCommentaire()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AjouterCommentaire(Commentaire commentaire)
        {
            commentaire.DateCreation = DateTime.Now;
            commentaire = new CommentaireRepository().AddOneCommentaire(commentaire);

            if (commentaire == null)
                ViewBag.MessageAjout = "Erreur";
            else
                ViewBag.MessageAjout = "Le commentaire est ajouté";
            return View();
        }

        public ActionResult VoirCommentaire(int id = 0)
        {
            Commentaire commentaire = new CommentaireRepository().FindOneCommentaireById(id);

            if (commentaire == null)
                return RedirectToAction("Index");

            return View(commentaire);
        }

        public ActionResult SupprimerCommentaire(int id = 0)
        {
            Commentaire commentaire = new CommentaireRepository().DelOneCommentaire(id);

            if (commentaire == null)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index");
        }

        public ActionResult ModifierCommentaire(int id = 0)
        {
            Commentaire commentaire = new CommentaireRepository().FindOneCommentaireById(id);

            if (commentaire != null)
                return View(commentaire);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ModifierCommentaire(Commentaire commentaire)
        {
            commentaire = new CommentaireRepository().AmendCommentaire(commentaire);

            if (commentaire != null)
            {
                ViewBag.Message = "Modification validée";
                return View(commentaire);
            }

            return RedirectToAction("Index");
        }
    }
}